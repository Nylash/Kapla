using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Piece : MonoBehaviour
{
    public PieceType type;

    Rigidbody rigid;
    Collider coll;
    MeshRenderer meshRender;
    Material pieceOriginalMaterial;

    private void Start()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        meshRender = GetComponent<MeshRenderer>();
        pieceOriginalMaterial = meshRender.material;
    }

    public void Drop()
    {
        GameManager.instance.movingScript.currentPiece = null;
        rigid.useGravity = true;
        rigid.isKinematic = false;
        coll.isTrigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        GameManager.instance.movingScript.canDrop = false;
        meshRender.material = GameManager.instance.canDropMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.instance.movingScript.canDrop = true;
        meshRender.material = pieceOriginalMaterial;
    }

    public enum PieceType
    {
        neutral, gummy, sticky
    }
}
