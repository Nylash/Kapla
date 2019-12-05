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
    public Material[] pieceOriginalMaterials;
    bool toPlace;
    GameObject guide;
    int shakeScreenCounter = 3;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("ToPlace");
        rigid = GetComponentInChildren<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        colliders = GetComponentsInChildren<MeshCollider>();
        foreach (MeshCollider item in colliders)
        {
            item.isTrigger = true;
            item.gameObject.layer = LayerMask.NameToLayer("ToPlace");
        }
        meshRender = GetComponentInChildren<MeshRenderer>();
        pieceOriginalMaterials = meshRender.materials;
        toPlace = true;
        guide = Instantiate(GameManager.instance.guidePrefab, new Vector3(meshRender.bounds.center.x, meshRender.bounds.center.y / 2, meshRender.bounds.center.z), Quaternion.identity);
        guide.transform.localScale = new Vector3(meshRender.bounds.size.x, (1.95f * meshRender.bounds.center.y)/4.3f, meshRender.bounds.size.z);
    }

    public void Drop()
    {
        Destroy(guide);
        GameManager.instance.movingScript.currentPiece = null;
        rigid.useGravity = true;
        rigid.isKinematic = false;
        foreach (MeshCollider item in colliders)
        {
                item.isTrigger = false; 
            item.gameObject.layer = LayerMask.NameToLayer("Placed");
        }
        gameObject.layer = LayerMask.NameToLayer("Placed");
        toPlace = false;
        meshRender.materials = pieceOriginalMaterials;
    }

    private void Update()
    {
        if (toPlace)
        {
            guide.transform.position = new Vector3(meshRender.bounds.center.x, meshRender.bounds.center.y/2, meshRender.bounds.center.z);
            guide.transform.localScale = new Vector3(meshRender.bounds.size.x, (1.95f * meshRender.bounds.center.y) / 4.3f, meshRender.bounds.size.z);
        }
    }

    private void OnDrawGizmos()
    {
        if (toPlace)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(meshRender.bounds.center, meshRender.bounds.size);
            Gizmos.DrawWireSphere(new Vector3(meshRender.bounds.center.x, meshRender.bounds.center.y / 2, meshRender.bounds.center.z), .2f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("DeadZone"))
        {
            if(shakeScreenCounter != 0)
            {
                shakeScreenCounter--;
                StartCoroutine(GameManager.instance.Shake());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (toPlace && other.gameObject.layer != LayerMask.NameToLayer("ToPlace"))
        {
            GameManager.instance.movingScript.canDrop = false;
            if(meshRender.materials[0] != GameManager.instance.cantDropMaterial)
            {
                Material[] tmp = meshRender.materials;
                for (int i = 0; i < meshRender.materials.Length; i++)
                {
                    tmp[i] = GameManager.instance.cantDropMaterial;
                }
                meshRender.materials = tmp;
            }   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (toPlace && other.gameObject.layer != LayerMask.NameToLayer("ToPlace"))
        {
            GameManager.instance.movingScript.canDrop = true;
            meshRender.materials = pieceOriginalMaterials;
        }
    }

    public enum PieceType
    {
        neutral, gummy, sticky
    }
}
