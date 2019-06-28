using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public static AudioClip backSound, buttonSound, cheerSound, correctSound, gameOverSound, resumeSound, pickUpSound, wrongSound;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        backSound = Resources.Load<AudioClip>("Back");
        buttonSound = Resources.Load<AudioClip>("Button");
        cheerSound = Resources.Load<AudioClip>("Cheer");
        correctSound = Resources.Load<AudioClip>("Correct");
        gameOverSound = Resources.Load<AudioClip>("GameOver");
        resumeSound = Resources.Load<AudioClip>("Resume");
        pickUpSound = Resources.Load<AudioClip>("PickUp");
        wrongSound = Resources.Load<AudioClip>("Wrong");

        audioSrc = GetComponent<AudioSource>();
	}
	
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "back":
                audioSrc.PlayOneShot(backSound);
                break;

            case "button":
                audioSrc.PlayOneShot(buttonSound);
                break;

            case "cheer":
                audioSrc.PlayOneShot(cheerSound);
                break;

            case "correct":
                audioSrc.PlayOneShot(correctSound);
                break;

            case "gameOver":
                audioSrc.PlayOneShot(gameOverSound);
                break;

            case "resume":
                audioSrc.PlayOneShot(resumeSound);
                break;

            case "pickUp":
                audioSrc.PlayOneShot(pickUpSound);
                break;

            case "wrong":
                audioSrc.PlayOneShot(wrongSound);
                break;
        }

    }
}
