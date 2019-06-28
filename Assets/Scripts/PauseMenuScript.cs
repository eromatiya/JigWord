using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

    public GameObject pauseMenuUI;
    public GameObject goBackMenuUI;
    public GameObject restartMenuUI;
    public GameObject clueUI;
    public Button clueUIXbutton;

    public void ShowBackToMenu()
    {
        SoundManagerScript.PlaySound("button");
        pauseMenuUI.SetActive(false);
        goBackMenuUI.SetActive(true);
    }

    public void PauseGame()
    {
        SoundManagerScript.PlaySound("button");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowPause()
    {
        SoundManagerScript.PlaySound("back");
        restartMenuUI.SetActive(false);
        goBackMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        SoundManagerScript.PlaySound("resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowRestartMenu()
    {
        SoundManagerScript.PlaySound("button");
        pauseMenuUI.SetActive(false);
        restartMenuUI.SetActive(true);
    }

    public void Restart()
    {
        SoundManagerScript.PlaySound("button");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void LoadStartMenu()
    {
        SoundManagerScript.PlaySound("button");
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }

    public void ShowClue()
    {
        SoundManagerScript.PlaySound("button");
        clueUI.SetActive(true);
        StartCoroutine(delay());
    }

    public void CloseClue()
    {
        SoundManagerScript.PlaySound("back");
        clueUI.SetActive(false);
        clueUIXbutton.interactable = false;
        Time.timeScale = 1f;
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.2f);
        clueUIXbutton.interactable = true;
        Time.timeScale = 0f;
    }


}
