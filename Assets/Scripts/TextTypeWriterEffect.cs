using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextTypeWriterEffect : MonoBehaviour {

    private float delay;
    public string fullText;
    private string currentText = "";

	// Use this for initialization
	void Start ()
    {
        delay = 0.1f;
        StartCoroutine(showText());
	}


    IEnumerator showText()
    {
        
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
	

}
