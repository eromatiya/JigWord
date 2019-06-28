using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreGameOver : MonoBehaviour
{
    public static int score;
    public GameObject NewBest;
    public GameObject NewBestPanel;
    public GameObject HighScorePanel;
    public GameObject gameOverScore;
    public GameObject highScore;
    private static int currentHighScore1;
    private static int currentHighScore2;
    private static int currentHighScore3;

    
    void Awake()
    {
        currentHighScore1 = 0;
        currentHighScore2 = 0;
        currentHighScore3 = 0;

        if (LevelManager.whichlevel == 1)
        {
            if (PlayerPrefs.HasKey("HighScore1"))
            {
                currentHighScore1 = PlayerPrefs.GetInt("HighScore1", currentHighScore1);
                highScore.GetComponent<TextMeshProUGUI>().SetText(currentHighScore1.ToString());
            }
        }
        else if (LevelManager.whichlevel == 2)
        {
            if (PlayerPrefs.HasKey("HighScore2"))
            {
                currentHighScore2 = PlayerPrefs.GetInt("HighScore2", currentHighScore2);
                highScore.GetComponent<TextMeshProUGUI>().SetText(currentHighScore2.ToString());
            }
        }
        else if (LevelManager.whichlevel == 3)
        {
            if (PlayerPrefs.HasKey("HighScore3"))
            {
                currentHighScore3 = PlayerPrefs.GetInt("HighScore3", currentHighScore3);
                highScore.GetComponent<TextMeshProUGUI>().SetText(currentHighScore3.ToString());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = MovePiece.score;
        gameOverScore.GetComponent<TextMeshProUGUI>().SetText(score.ToString());
        
        if (LevelManager.whichlevel == 1)
        {
            if (currentHighScore1 < score)
            {
                currentHighScore1 = score;
                PlayerPrefs.SetInt("HighScore1", currentHighScore1);
                NewBestPanel.SetActive(true);
                HighScorePanel.SetActive(false);
                NewBest.GetComponent<TextMeshProUGUI>().SetText(currentHighScore1.ToString());
            }
        }
        
        else if (LevelManager.whichlevel == 2)
        {
            if (currentHighScore2 < score)
            {
                currentHighScore2 = score;
                PlayerPrefs.SetInt("HighScore2", currentHighScore2);
                NewBestPanel.SetActive(true);
                HighScorePanel.SetActive(false);
                NewBest.GetComponent<TextMeshProUGUI>().SetText(currentHighScore2.ToString());
            }
        }
        
        else if (LevelManager.whichlevel == 3)
        {
            if (currentHighScore3 < score)
            {
                currentHighScore3 = score;
                PlayerPrefs.SetInt("HighScore3", currentHighScore3);
                NewBestPanel.SetActive(true);
                HighScorePanel.SetActive(false);
                NewBest.GetComponent<TextMeshProUGUI>().SetText(currentHighScore3.ToString());
            }
        }

    }
}
