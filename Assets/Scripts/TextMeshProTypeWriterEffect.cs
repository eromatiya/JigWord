using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TextMeshProTypeWriterEffect : MonoBehaviour {

    private float delay;
    public string fullText;
    private string currentText = "";

	// Use this for initialization
	void Start ()
    {
        delay = 0.01f;
        StartCoroutine(showText());
	}


    IEnumerator showText()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().SetText(currentText);
            yield return new WaitForSeconds(delay);
        }
    }
	

}
