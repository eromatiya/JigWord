using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int Level;
    public Image Image;
    private string LevelString;
    public static int whichlevel;

    void Start()
    {
        if (ButtonSettings.releasedLevelStatic >= Level)
        {
            Levelunlocked();
        }
        else
        {
            Levellocked();
        }
    }


    public void LevelSelect(string _level)
    {
        SoundManagerScript.PlaySound("button");
        whichlevel = Level;
        LevelString = _level;
        SceneManager.LoadScene(LevelString);
    }

    void Levellocked()
    {
        GetComponent<Button>().interactable = false;
        Image.enabled = true;
    }

    void Levelunlocked()
    {
        GetComponent<Button>().interactable = true;
        Image.enabled = false;
    }

}
