using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreUI, promptUI, currentScoreUI;
    public GameObject uiScreen;
    public float promptSpeed;
    bool startButtonPressed = false, promptDisabled = false ;
    public event Action LoadingComplete, UpdateScore;
    Color finalColor;
    int currentScore = 0;
    Player player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Make sure the StartGame Method Runs Till Compeletion.
        {
            startButtonPressed = true;  
        }
        
        if (startButtonPressed)
        {
            StartGame();  
        } else {
            if (!promptDisabled)
            {
                if(promptUI.color.a > 0.99){
                    finalColor = Color.clear;
                } else if(promptUI.color.a < 0.01)
                {
                    finalColor = Color.white;
                }
                promptUI.color = Color.Lerp(promptUI.color, finalColor, promptSpeed);
            }
            
        }
    }

    void StartGame(){
        if (uiScreen.transform.localScale.x > 40)
        {
            uiScreen.SetActive(false);
            currentScoreUI.color = Color.Lerp(currentScoreUI.color, new Color(1,1,1,0.9f), 0.5f);
            LoadingComplete?.Invoke();
            player = FindObjectOfType<Player>();
            player.UpdateScore += ScoreUpdate;
            startButtonPressed = promptDisabled = false;
            
        } else
        {
            uiScreen.transform.localScale += Vector3.one * 0.5f;
        }
    }

    void ScoreUpdate(){
        currentScore++;
        currentScoreUI.text = currentScore.ToString();
    }
}
