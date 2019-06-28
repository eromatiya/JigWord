using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSettings : MonoBehaviour {
   
    public GameObject triviaUI;
    public GameObject levelcompleteUI;
    public GameObject backtoMenuUI;
    public GameObject gameOverUI;
    public static int releasedLevelStatic = 1;
    public int releasedLevel;
    public string nextLevel;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            releasedLevelStatic = PlayerPrefs.GetInt("Level", releasedLevelStatic);
    
        }
    }

    public void NextLevel()
    {
        LevelManager.whichlevel = releasedLevel;
        Destroy(gameOverUI);
        MovePiece.score = 0;
        ScoreControl.TotalScore = 0;
        ScoreGameOver.score = 0;
        Timer.totalTime = 0;
        SceneManager.LoadScene(nextLevel);
        
        
    }

    public void Restart()
    {
        SoundManagerScript.PlaySound("button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowBacktoMenu()
    {
        SoundManagerScript.PlaySound("button");
        backtoMenuUI.SetActive(true);
    }

    public void BacktoMenu()
    {
        SoundManagerScript.PlaySound("button");
        SceneManager.LoadScene("StartMenu");
    }

    public void No()
    {
        SoundManagerScript.PlaySound("back");
        backtoMenuUI.SetActive(false);
    }

    public void Next()
    {
        SoundManagerScript.PlaySound("button");
        triviaUI.SetActive(false);
        levelcompleteUI.SetActive(true);
               
        if (releasedLevelStatic <= releasedLevel)
        {
            releasedLevelStatic = releasedLevel;
            PlayerPrefs.SetInt("Level", releasedLevelStatic);
        }

        
    }

}
