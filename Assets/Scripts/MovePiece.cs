using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{

    public string pieceStatus = "";

    public Transform edgeParticles;

    public string checkPlacement = "";

    public float yDiff;
    public Vector2 invPos;

    public static int score;

    public float newYPOS;

    // Update is called once per frame
    void Update()
    {
        invControl();

        if ((Input.GetMouseButtonUp(0)) && (pieceStatus == "pickedup"))
        {
            checkPlacement = "y";
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (((other.gameObject.name != gameObject.name) && (other.gameObject.name == "ReturnPieceButton")) && (checkPlacement == "y"))
        {
            transform.position = new Vector2(-6.75f, invPos.y + yDiff);
            pieceStatus = "";
            ReturnPiece.piece = "";
            checkPlacement = "n";
            SoundManagerScript.PlaySound("back");
        }

        else if ((other.gameObject.name == gameObject.name) && (checkPlacement == "y"))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            other.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 0;
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            Instantiate(edgeParticles, other.gameObject.transform.position, edgeParticles.rotation);
            checkPlacement = "n";
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            score += 10;
            GameMaster.remainingPieces -= 1;
            SoundManagerScript.PlaySound("correct");
           
        }

        else if (((other.gameObject.name != gameObject.name) && (other.gameObject.tag != "piece")) && (checkPlacement == "y"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            checkPlacement = "n";
            SoundManagerScript.PlaySound("wrong");
            GameMaster.lives -= 1;
        }
    }

    void OnMouseDown()
    {
        pieceStatus = "pickedup";
        checkPlacement = "n";
        GetComponent<Renderer>().sortingOrder = 10;
        SoundManagerScript.PlaySound("pickUp");
        invPos = transform.position;
    }

    void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    public void invControl()
    {
        if ((ReturnPiece.piece == "return") && (pieceStatus == "pickedup"))
        {
            transform.position = new Vector2(-6.75f, invPos.y + yDiff);
            pieceStatus = "";
            ReturnPiece.piece = "";
        }


        if ((pieceStatus != "pickedup") && (pieceStatus != "locked"))
        {
            transform.position = new Vector2(-6.75f, newYPOS + Arrow.invAdj);
        }

    }


}
