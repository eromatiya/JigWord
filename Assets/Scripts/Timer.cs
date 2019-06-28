using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    public static float totalTime = 122f;
    private int minutes;
    private int seconds;
    public GameObject clock;

    private void Update()
    {
        UpdateLevelTimer(totalTime);
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        minutes = Mathf.FloorToInt(totalSeconds / 60f);
        seconds = Mathf.RoundToInt(totalSeconds % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        clock.GetComponent<TextMeshProUGUI>().SetText(minutes.ToString("00") + ":" + seconds.ToString("00"));
    }
}
