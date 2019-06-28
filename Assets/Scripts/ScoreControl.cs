using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControl : MonoBehaviour
{

    public GameObject TimeBonus;
    public GameObject Score;
    public GameObject Total;
    public GameObject HighScore;
    public GameObject NewBest;

    public GameObject NewBestPanel;
    public GameObject HighScorePanel;

    public static int TotalScore;
    public static int currentHighScore1;
    public static int currentHighScore2;
    public static int currentHighScore3;


    // Use this for initialization
    void Awake()
    {
        currentHighScore1 = 0;
        currentHighScore2 = 0;
        currentHighScore3 = 0;

        Score.GetComponent<TextMeshProUGUI>().SetText(MovePiece.score.ToString());
        TimeBonus.GetComponent<TextMeshProUGUI>().SetText(Mathf.RoundToInt(Timer.totalTime).ToString());

        if (LevelManager.whichlevel == 1)
        {
            if (PlayerPrefs.HasKey("HighScore1"))
            {
                currentHighScore1 = PlayerPrefs.GetInt("HighScore1",currentHighScore1);
                HighScore.GetComponent<TextMeshProUGUI>().SetText(currentHighScore1.ToString());
            }
        }

        else if (LevelManager.whichlevel == 2)
        {
            if (PlayerPrefs.HasKey("HighScore2"))
            {
                currentHighScore2 = PlayerPrefs.GetInt("HighScore2",currentHighScore2);
                HighScore.GetComponent<TextMeshProUGUI>().SetText(currentHighScore2.ToString());
            }
        }

        else if (LevelManager.whichlevel == 3)
        {
            if (PlayerPrefs.HasKey("HighScore3"))
            {
                currentHighScore3 = PlayerPrefs.GetInt("HighScore3",currentHighScore3);
                HighScore.GetComponent<TextMeshProUGUI>().SetText(currentHighScore3.ToString());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        TotalScore = Mathf.RoundToInt(MovePiece.score + Timer.totalTime);
        Total.GetComponent<TextMeshProUGUI>().SetText(TotalScore.ToString());

        if (LevelManager.whichlevel == 1)
        {
            if (currentHighScore1 < TotalScore)
            {
                currentHighScore1 = TotalScore;
                PlayerPrefs.SetInt("HighScore1", currentHighScore1);
                NewBestPanel.SetActive(true);
                HighScorePanel.SetActive(false);
                NewBest.GetComponent<TextMeshProUGUI>().SetText(currentHighScore1.ToString());
                
            }
        }

        else if (LevelManager.whichlevel == 2)
        {
            if (currentHighScore2 < TotalScore)
            {
                currentHighScore2 = TotalScore;
                PlayerPrefs.SetInt("HighScore2", currentHighScore2);
                NewBestPanel.SetActive(true);
                HighScorePanel.SetActive(false);
                NewBest.GetComponent<TextMeshProUGUI>().SetText(currentHighScore2.ToString());
                
            }
        }
        else if (LevelManager.whichlevel == 3)
        {
            if (currentHighScore3 < TotalScore)
            {
                currentHighScore3 = TotalScore;
                PlayerPrefs.SetInt("HighScore3", currentHighScore3);
                NewBestPanel.SetActive(true);
                HighScorePanel.SetActive(false);
                NewBest.GetComponent<TextMeshProUGUI>().SetText(currentHighScore3.ToString());
            }
        }
    }
}
