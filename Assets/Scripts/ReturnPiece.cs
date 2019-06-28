using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPiece : MonoBehaviour {
    public static string piece = "";
	
	void OnMouseDown()
    {
        if (gameObject.name == "ReturnPieceButton")
        {
            piece = "return";
            SoundManagerScript.PlaySound("back");
        }
        

        
    }
}
