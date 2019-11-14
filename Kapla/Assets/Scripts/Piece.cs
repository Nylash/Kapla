using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Piece : MonoBehaviour
{
    [Header("PIECE CONFIGURATION")]
    public PieceType type;
    [HideInInspector]
    public LineRenderer line;
    Rigidbody rigid;
    Collider coll;
    MeshRenderer meshRender;
    Material pieceOriginalMaterial;

    bool toPlace;
    RaycastHit hit;

    private void Start()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        meshRender = GetComponent<MeshRenderer>();
        pieceOriginalMaterial = meshRender.material;
        toPlace = true;
        gameObject.AddComponent<LineRenderer>();
        line = GetComponent<LineRenderer>();
        line.material = GameManager.instance.cantDropMaterial;
        line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        line.startWidth = .05f;
        line.endWidth = .05f;
    }

    public void Drop()
    {
        GameManager.instance.movingScript.currentPiece = null;
        Destroy(line);
        rigid.useGravity = true;
        rigid.isKinematic = false;
        coll.isTrigger = false;
        toPlace = false;
        if (meshRender.material != pieceOriginalMaterial)
            meshRender.material = pieceOriginalMaterial;
    }

    private void Update()
    {
        if (toPlace)
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
            {
                if (line)
                {
                    line.SetPosition(0, transform.position);
                    line.SetPosition(1, hit.point);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (toPlace)
        {
            GameManager.instance.movingScript.canDrop = false;
            meshRender.material = GameManager.instance.cantDropMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (toPlace)
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
