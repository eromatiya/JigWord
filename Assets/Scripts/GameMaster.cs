using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public static int remainingPieces;
    public GameObject triviaUI;
    public GameObject gameOverUI;
    public GameObject nextButton;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;
    public Button clueXbutton;
    public static int lives;
    AudioSource BGM;
    
    // Use this for initialization
    void Start()
    {
        Timer.totalTime = 122f;
        MovePiece.score = 0;
        Arrow.invAdj = 0;

        StartCoroutine(StopTime());

        lives = 5;
        heart5.SetActive(true);
        heart4.SetActive(true);
        heart3.SetActive(true);
        heart2.SetActive(true);
        heart1.SetActive(true);

        if (LevelManager.whichlevel == 1)
        {
            remainingPieces = 9;
        }
        else if (LevelManager.whichlevel == 2)
        {
            remainingPieces = 12;
        }
        else if (LevelManager.whichlevel == 3)
        {
            remainingPieces = 16;
        }
        BGM = GetComponent<AudioSource>();
        BGM.Play();
	}
		
	// Update is called once per frame
	void Update () {
        
        switch (lives)
        {
            case 5:
                heart5.SetActive(true);
                heart4.SetActive(false);
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(false);
                break;

            case 4:
                heart5.SetActive(false);
                heart4.SetActive(true);
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(false);
                break;
            
            case 3:
                heart5.SetActive(false);
                heart4.SetActive(false);
                heart3.SetActive(true);
                heart2.SetActive(false);
                heart1.SetActive(false);
                break;
            
            case 2:
                heart5.SetActive(false);
                heart4.SetActive(false);
                heart3.SetActive(false);
                heart2.SetActive(true);
                heart1.SetActive(false);
                break;
            
            case 1:
                heart5.SetActive(false);
                heart4.SetActive(false);
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(true);
                break;
            
            case 0:
                heart5.SetActive(false);
                heart4.SetActive(false);
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(false);
                gameOverUI.SetActive(true);
                BGM.Stop();
                break;
        }

        if (remainingPieces > 0)
        {
           Timer.totalTime -= Time.deltaTime;
        }
        
        if (remainingPieces == 0)
        {
            StartCoroutine(LateCall());
            BGM.Stop();
            remainingPieces -= 1;
            StartCoroutine(delayButton());
        }

        if (Timer.totalTime <= 0 && lives > 0)
        {
            Timer.totalTime = 0;
            gameOverUI.SetActive(true);
            BGM.Stop();
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(1f);
        triviaUI.SetActive(true);
    }

    IEnumerator delayButton()
    {
        yield return new WaitForSeconds(7.5f);
        nextButton.SetActive(true);
    }

    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(1.2f);
        clueXbutton.interactable = true;
        Time.timeScale = 0f;
    }

}
