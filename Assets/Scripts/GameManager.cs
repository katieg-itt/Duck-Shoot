using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public DuckScript duck;
    public int scoreNumber;
    
    private GameObject scoreText;
    private GameObject livesText;
    private bool choiceMade;
    public GameObject videoChoicePanel;
    private bool showVideoChoiceYes;
    public Adverts AdsManager;
    private bool adMobTurn;

    // Use this for initialization
    void Start () {
        AdsManager.RequestBanner();
        videoChoicePanel.SetActive(false);
        scoreText = GameObject.Find("Score");
        livesText = GameObject.Find("Lives");

        duck.livesNumber = 3;
        scoreNumber = 0;

        updateScore();
        choiceMade = false;

    }

    // Update is called once per frame
    void Update () {
        
        if(duck.livesNumber <= 0)
        {
            
            gameOver();
        }



    }

    private void gameOver()
    {
        Time.timeScale = 0;
        extraLifeChoiceOption();
       

    }
   

    private void extraLifeChoiceOption()
    {
        

        videoChoicePanel.SetActive(true);

        if (choiceMade)
        {
            videoChoicePanel.SetActive(false);
            if (showVideoChoiceYes)
            {
                Debug.Log("Choose YES!!");
                if (adMobTurn)
                {
                    AdsManager.ShowRewardBasedVideo();
                    adMobTurn = false;
                }
                else
                {
                    AdsManager.ShowRewardedAd();
                    adMobTurn = true;
                }
                duck.livesNumber += 3;
                duck.generateCoordinates();
                updateScore();
                Time.timeScale = 1;
                choiceMade = false;
            }
            else
            {
                Debug.Log("Choose No!!");
                restartGame();
                choiceMade = false;
                Time.timeScale = 1;
            }
        }
        else
        {
            videoChoicePanel.SetActive(true);
            choiceMade = false;
        }

    }

    private void restartGame()
    {
        duck.livesNumber = 3;
        scoreNumber = 0;
        duck.generateCoordinates();
    }

    public void extraLifeChoiceYes()
    {
        choiceMade = true;
        showVideoChoiceYes = true;
    }
    public void extraLifeChoiceNo()
    {
        choiceMade = true;
        showVideoChoiceYes = false;
    }

    internal void updateScore()
    {
        //Update the score display
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + scoreNumber;
        livesText.GetComponent<UnityEngine.UI.Text>().text = "Lives: " + duck.livesNumber;
    }
}
