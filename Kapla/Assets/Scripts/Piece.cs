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
    bool fxDone;
    bool deathFXDone;

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
        toPlace = false;
        Destroy(guide);
        rigid.useGravity = true;
        rigid.isKinematic = false;
        foreach (MeshCollider item in colliders)
            item.isTrigger = false;
        meshRender.materials = pieceOriginalMaterials;
        GameManager.instance.SetLastPlayer();
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

    IEnumerator NewTurn()
    {
        yield return new WaitForSeconds(.2f);
        StartCoroutine(GameManager.instance.ChangePlayer());
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.AllPieces.Add(gameObject);
        GameManager.instance.InstantiateNewPiece();
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
            if (!fxDone)
            {
                Instantiate(GameManager.instance.dropFX,new Vector3(transform.position.x, collision.GetContact(0).point.y, transform.position.z), GameManager.instance.dropFX.transform.rotation);
                fxDone = true;
            }
            if(gameObject.layer == 9)
            {
                foreach (MeshCollider item in colliders)
                    item.gameObject.layer = LayerMask.NameToLayer("Placed");
                gameObject.layer = LayerMask.NameToLayer("Placed");
                StartCoroutine(NewTurn());
            }
        }
        else
        {
            if (!deathFXDone)
            {
                Instantiate(GameManager.instance.deathFX, collision.GetContact(0).point+new Vector3(0,.5f,0), GameManager.instance.deathFX.transform.rotation);
                deathFXDone = true;
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
