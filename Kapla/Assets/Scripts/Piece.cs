using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Piece : MonoBehaviour
{
    [Header("PIECE CONFIGURATION")]
    public PieceType type;

    Rigidbody rigid;
    MeshCollider[] colliders;
    MeshRenderer meshRender;
    Material pieceOriginalMaterial;
    bool toPlace;
    GameObject column;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("ToPlace");
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        colliders = GetComponentsInChildren<MeshCollider>();
        foreach (MeshCollider item in colliders)
        {
            item.isTrigger = true;
            item.gameObject.layer = LayerMask.NameToLayer("ToPlace");
        }
        meshRender = transform.GetChild(0).GetComponent<MeshRenderer>();
        meshRender.gameObject.layer = LayerMask.NameToLayer("ToPlace");
        pieceOriginalMaterial = meshRender.material;
        toPlace = true;
        column = Instantiate(GameManager.instance.collumnPrefab, new Vector3(meshRender.bounds.center.x, meshRender.bounds.center.y / 2, meshRender.bounds.center.z), Quaternion.identity);
        column.transform.localScale = new Vector3(meshRender.bounds.size.x, (1.95f * meshRender.bounds.center.y)/4.3f, meshRender.bounds.size.z);
    }

    public void Drop()
    {
        Destroy(column);
        GameManager.instance.movingScript.currentPiece = null;
        rigid.useGravity = true;
        rigid.isKinematic = false;
        foreach (MeshCollider item in colliders)
        {
                item.isTrigger = false; 
            item.gameObject.layer = LayerMask.NameToLayer("Placed");
        }
        gameObject.layer = LayerMask.NameToLayer("Placed");
        meshRender.gameObject.layer = LayerMask.NameToLayer("Placed");
        toPlace = false;
        if (meshRender.material != pieceOriginalMaterial)
            meshRender.material = pieceOriginalMaterial;
    }

    private void Update()
    {
        if (toPlace)
        {
            column.transform.position = new Vector3(meshRender.bounds.center.x, transform.position.y/2, meshRender.bounds.center.z);
            column.transform.localScale = new Vector3(meshRender.bounds.size.x, (1.95f * meshRender.bounds.center.y) / 4.3f, meshRender.bounds.size.z);
        }
    }

    private void OnDrawGizmos()
    {
        if (toPlace)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(meshRender.bounds.center, meshRender.bounds.size);
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
