using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour {

    public Button UpButton;
    public Button DownButton;
    public static float invAdj = 0;

	public void Up()
    {
        invAdj += 2.47f;
        
        if (LevelManager.whichlevel == 1)
        {
            if (invAdj < 17.29f) 
            {
                DownButton.interactable = true;
            }
            else
                UpButton.interactable = false;
        }

        else if (LevelManager.whichlevel == 2)
        {
            if (invAdj < 22.3f) 
            {
                DownButton.interactable = true;
            }
            else
                UpButton.interactable = false;
        }

        else if (LevelManager.whichlevel == 3)
        {
            if (invAdj < 32.11f) 
            {
                DownButton.interactable = true;
            }
            else
                UpButton.interactable = false;
        }

        
    }

    public void Down()
    {
        invAdj -= 2.47f;
        
        if (LevelManager.whichlevel == 1)
        {
            if (invAdj > -17.29f)
            {
                UpButton.interactable = true;
            }
            else
                DownButton.interactable = false;
        }

        else if (LevelManager.whichlevel == 2)
        {
            if (invAdj > -22.3f)
            {
                UpButton.interactable = true;
            }
            else
                DownButton.interactable = false;
        }

        else if (LevelManager.whichlevel == 3)
        {
            if (invAdj > -32.11f)
            {
                UpButton.interactable = true;
            }
            else
                DownButton.interactable = false;
        }
    }

}
