using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideScript : MonoBehaviour
{
    public Piece currentPiece;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer == 8)
        {
            if (currentPiece.refPosY < other.transform.position.y)
                currentPiece.refPosY = other.transform.position.y;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            if (currentPiece.refPosY < other.transform.position.y)
                currentPiece.refPosY = other.transform.position.y;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentPiece.refPosY = 0;
    }
}
