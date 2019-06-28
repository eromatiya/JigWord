using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour {

    private float sec = 1.5f;
    private int currentHighScore1;
    private int currentHighScore2;
    private int currentHighScore3;
    public GameObject HowToPlayUI;
    public GameObject LevelSelectUI;
    public GameObject HighScoreUI;
    public GameObject CreditsUI;
    public GameObject ResetProgressUI;
    public GameObject ResetUI;
    public GameObject QuitGameUI;
    public GameObject hs1;
    public GameObject hs2;
    public GameObject hs3;
    public GameObject instruction1;
    public GameObject instruction11;
    public Image image1;
    public Image image2;
    public Button button1;
    public Button button2;
    
    
    void Start()
    {
        currentHighScore1 = 0;
        currentHighScore2 = 0;
        currentHighScore3 = 0;

        if (PlayerPrefs.HasKey("HighScore1"))
        {
            currentHighScore1 = PlayerPrefs.GetInt("HighScore1", currentHighScore1);
            hs1.GetComponent<TextMeshProUGUI>().SetText(currentHighScore1.ToString());
        }
        else
            hs1.GetComponent<TextMeshProUGUI>().SetText("0");

        if (PlayerPrefs.HasKey("HighScore2"))
        {
            currentHighScore2 = PlayerPrefs.GetInt("HighScore2", currentHighScore2);
            hs2.GetComponent<TextMeshProUGUI>().SetText(currentHighScore2.ToString());
        }
        else
            hs2.GetComponent<TextMeshProUGUI>().SetText("0");

        if (PlayerPrefs.HasKey("HighScore3"))
        {
            currentHighScore3 = PlayerPrefs.GetInt("HighScore3", currentHighScore3);
            hs3.GetComponent<TextMeshProUGUI>().SetText(currentHighScore3.ToString());
        }
        else
            hs3.GetComponent<TextMeshProUGUI>().SetText("0");

       
    }

    
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (QuitGameUI.activeSelf == true)
                {
                    ShowStartMenu();
                }
                else if (ResetUI.activeSelf == true)
                {
                    ShowStartMenu();
                }
                else if (ResetProgressUI.activeSelf == true)
                {
                    ShowStartMenu();
                }
                else if (CreditsUI.activeSelf == true)
                {
                    ShowStartMenu();
                }
                else if (HighScoreUI.activeSelf == true)
                {
                    ShowStartMenu();
                }
                else if (HowToPlayUI.activeSelf == true)
                {
                    exitHowToPlay();
                }
                else if (LevelSelectUI.activeSelf == true)
                {
                    ShowStartMenu();
                }
                
                else
                    ShowQuit();

            }
        }
    }
    
    public void Play()
    {
        SoundManagerScript.PlaySound("button");
        LevelSelectUI.SetActive(true);
        if(!PlayerPrefs.HasKey("HowToPlay"))
        {
            HowToPlayUI.SetActive(true);
            PlayerPrefs.SetString("HowToPlay","True");
        }
    }

    public void HighScore()
    {
        SoundManagerScript.PlaySound("button");
        HighScoreUI.SetActive(true);
    }
    
    public void exitHowToPlay()
    {
        SoundManagerScript.PlaySound("back");
        HowToPlayUI.SetActive(false);   
    }

    public void ShowResetProgress()
    {
        SoundManagerScript.PlaySound("button");
        LevelSelectUI.SetActive(true);
        ResetProgressUI.SetActive(true);
        StartCoroutine(DelayCall());
    }

    IEnumerator DelayCall()
    {
        yield return new WaitForSeconds(.01f);
        LevelSelectUI.SetActive(false);
    }

    public void ResetProgress()
    {
        SoundManagerScript.PlaySound("button");
        PlayerPrefs.DeleteAll();
        instruction11.SetActive(false);
        instruction1.SetActive(true);
        button1.interactable = false;
        image1.enabled = true;
        button2.interactable = false;
        image2.enabled = true;
        hs1.GetComponent<TextMeshProUGUI>().SetText("0");
        hs2.GetComponent<TextMeshProUGUI>().SetText("0");
        hs3.GetComponent<TextMeshProUGUI>().SetText("0");
        ButtonSettings.releasedLevelStatic = 1;
        ResetUI.SetActive(true);
        StartCoroutine(LateCall());
    }


    IEnumerator LateCall()
    {
        LevelSelectUI.SetActive(false);
        ResetProgressUI.SetActive(false);
        yield return new WaitForSeconds(sec);
        ResetUI.SetActive(false);
    }

    public void Credits()
    {
        SoundManagerScript.PlaySound("button");
        CreditsUI.SetActive(true);
    }

    public void ShowStartMenu()
    {
        SoundManagerScript.PlaySound("back");
        LevelSelectUI.SetActive(false);
        HighScoreUI.SetActive(false);
        CreditsUI.SetActive(false);
        ResetProgressUI.SetActive(false);
        QuitGameUI.SetActive(false);
    }

    public void ShowQuit()
    {
        SoundManagerScript.PlaySound("button");
        QuitGameUI.SetActive(true);
     
    }

    public void Quit()
    {
        Application.Quit();
    }

}
