using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour {

    public GameObject Score;

	// Update is called once per frame
	void Update () {
        Score.GetComponent<TextMeshProUGUI>().SetText(MovePiece.score.ToString());
	}
}
