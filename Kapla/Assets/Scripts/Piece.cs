using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Piece : MonoBehaviour
{
    [Header("PIECE CONFIGURATION")]
    public PieceType type;

    Rigidbody rigid;
    Collider coll;
    MeshRenderer meshRender;
    Material pieceOriginalMaterial;
    bool toPlace;
    GameObject column;

    private void Start()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("ToPlace");
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        meshRender = GetComponent<MeshRenderer>();
        pieceOriginalMaterial = meshRender.material;
        toPlace = true;
        column = Instantiate(GameManager.instance.collumnPrefab, new Vector3(coll.bounds.center.x, coll.bounds.center.y / 2, coll.bounds.center.z), Quaternion.identity);
        column.transform.localScale = new Vector3(coll.bounds.size.x, (1.95f * coll.bounds.center.y)/4.3f, coll.bounds.size.z);
    }

    public void Drop()
    {
        Destroy(column);
        GameManager.instance.movingScript.currentPiece = null;
        rigid.useGravity = true;
        rigid.isKinematic = false;
        coll.isTrigger = false;
        gameObject.layer = LayerMask.NameToLayer("Placed");
        toPlace = false;
        if (meshRender.material != pieceOriginalMaterial)
            meshRender.material = pieceOriginalMaterial;
    }

    private void Update()
    {
        if (toPlace)
        {
            column.transform.position = new Vector3(coll.bounds.center.x, transform.position.y/2, coll.bounds.center.z);
            column.transform.localScale = new Vector3(coll.bounds.size.x, (1.95f * coll.bounds.center.y) / 4.3f, coll.bounds.size.z);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (toPlace && other.gameObject.layer != LayerMask.NameToLayer("ToPlace"))
        {
            GameManager.instance.movingScript.canDrop = false;
            if(meshRender.material != GameManager.instance.cantDropMaterial)
                meshRender.material = GameManager.instance.cantDropMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (toPlace && other.gameObject.layer != LayerMask.NameToLayer("ToPlace"))
        {
            GameManager.instance.movingScript.canDrop = true;
            meshRender.material = pieceOriginalMaterial;
        }
    }

    public enum PieceType
    {
        neutral, gummy, sticky
    }
}
