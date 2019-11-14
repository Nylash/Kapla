using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Piece : MonoBehaviour
{
    [Header("PIECE CONFIGURATION")]
    public PieceType type;

    Rigidbody rigid;
    Collider[] colliders;
    MeshRenderer[] meshRenders;
    Material pieceOriginalMaterial;
    bool toPlace;

    private void Start()
    {
        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider item in colliders)
        {
            item.isTrigger = true;
        }
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        meshRenders = GetComponentsInChildren<MeshRenderer>();
        pieceOriginalMaterial = meshRenders[0].material;
        toPlace = true;
    }

    public void Drop()
    {
        GameManager.instance.movingScript.currentPiece = null;
        rigid.useGravity = true;
        rigid.isKinematic = false;
        foreach (Collider item in colliders)
        {
            item.isTrigger = false;
        }
        toPlace = false;
        foreach (MeshRenderer item in meshRenders)
        {
            if (item.material != pieceOriginalMaterial)
                item.material = pieceOriginalMaterial;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (toPlace)
        {
            GameManager.instance.movingScript.canDrop = false;
            foreach (MeshRenderer item in meshRenders)
            {
                item.material = GameManager.instance.cantDropMaterial;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (toPlace)
        {
            GameManager.instance.movingScript.canDrop = true;
            foreach (MeshRenderer item in meshRenders)
            {
                item.material = pieceOriginalMaterial;
            }
        }
    }

    public enum PieceType
    {
        neutral, gummy, sticky
    }
}
