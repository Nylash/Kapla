using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainRigidbody : MonoBehaviour
{
    Piece pieceScript;

    void Awake()
    {
        pieceScript = GetComponentInParent<Piece>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        pieceScript.OnCollisionEnter(collision);
    }

    private void OnTriggerStay(Collider other)
    {
        pieceScript.OnTriggerStay(other);
    }

    private void OnTriggerExit(Collider other)
    {
        pieceScript.OnTriggerExit(other);
    }
}
