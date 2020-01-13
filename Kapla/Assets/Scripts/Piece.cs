using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [Header("PIECE CONFIGURATION")]
    public float arrowGuideOffset;
    public bool isTrain;
    public bool isBomb;
    public GameObject anchorBomb;
    public PieceSound fallSound;

    Rigidbody rigid;
    MeshCollider[] colliders;
    MeshRenderer meshRender;
    Material[] pieceOriginalMaterials;
    bool toPlace;
    GameObject guide;
    int shakeScreenCounter = 3;
    bool fxDone;
    bool deathFXDone;
    bool soundGroundDone;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("ToPlace");
        //RIGIDBODY
        if (!isTrain)
        {
            rigid = GetComponentInChildren<Rigidbody>();
            rigid.useGravity = false;
            rigid.isKinematic = true;
            //COLLIDERS
            colliders = GetComponentsInChildren<MeshCollider>();
            foreach (MeshCollider item in colliders)
            {
                item.isTrigger = true;
                item.gameObject.layer = LayerMask.NameToLayer("ToPlace");
            }
            //MESH RENDERER
            meshRender = GetComponentInChildren<MeshRenderer>();
        }
        else
        {
            rigid = transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
            meshRender = transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        }
        pieceOriginalMaterials = meshRender.materials;
        //GUIDE
        guide = Instantiate(GameManager.instance.guidePrefab, new Vector3(meshRender.bounds.center.x, meshRender.bounds.center.y / 2, meshRender.bounds.center.z), Quaternion.identity);
        guide.transform.localScale = new Vector3(meshRender.bounds.size.x, (1.95f * meshRender.bounds.center.y) / 4.3f, meshRender.bounds.size.z);
        toPlace = true;
    }

    public void Drop()
    {
        toPlace = false;
        Destroy(guide);
        if (!isTrain)
        {
            rigid.useGravity = true;
            rigid.isKinematic = false;
            foreach (MeshCollider item in colliders)
                item.isTrigger = false;
            meshRender.materials = pieceOriginalMaterials;
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i == 0)
                    transform.GetChild(i).gameObject.SetActive(false);
                else
                    transform.GetChild(i).gameObject.SetActive(true);
            }
        }
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

    IEnumerator NewTurn(bool addToPieces)
    {
        GameManager.instance.dropping = false;
        if (addToPieces)
        {
            GameManager.instance.AllPieces.Add(gameObject);
            yield return new WaitForSeconds(.2f);
        }   
        else
            yield return new WaitForSeconds(1);
        StartCoroutine(GameManager.instance.ChangePlayer());
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.InstantiateNewPiece();
    }

    public void PieceFallen()
    {
        gameObject.layer = LayerMask.NameToLayer("Placed");
        if (isBomb)
        {
            GameObject anchor = Instantiate(anchorBomb, transform.position + transform.up, transform.rotation);
            anchor.GetComponent<AnchorBomb>().bomb = gameObject;
            transform.GetChild(1).transform.gameObject.GetComponent<SpringJoint>().connectedBody = anchor.GetComponent<Rigidbody>();
            transform.GetChild(1).transform.gameObject.SetActive(true);
            transform.GetChild(2).transform.gameObject.SetActive(false);
        }
        if (!isTrain)
        {
            foreach (MeshCollider item in colliders)
                item.gameObject.layer = LayerMask.NameToLayer("Placed");
            if (isBomb)
                transform.GetChild(1).gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            foreach (Rigidbody item in GetComponentsInChildren<Rigidbody>())
                item.gameObject.layer = LayerMask.NameToLayer("Placed");
            foreach (MeshCollider item in GetComponentsInChildren<MeshCollider>())
                item.gameObject.layer = LayerMask.NameToLayer("Placed");
        }
        StartCoroutine(NewTurn(false));
    }

    public void OnCollisionEnter(Collision collision)
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
            if(gameObject.layer == LayerMask.NameToLayer("ToPlace"))
            {
                gameObject.layer = LayerMask.NameToLayer("Placed");
                if (isBomb)
                {
                    GameObject anchor = Instantiate(anchorBomb,transform.position + transform.up,transform.rotation);
                    anchor.GetComponent<AnchorBomb>().bomb = gameObject;
                    transform.GetChild(1).transform.gameObject.GetComponent<SpringJoint>().connectedBody = anchor.GetComponent<Rigidbody>();
                    transform.GetChild(1).transform.gameObject.SetActive(true);
                    transform.GetChild(2).transform.gameObject.SetActive(false);
                }
                if (!isTrain)
                {
                    foreach (MeshCollider item in colliders)
                        item.gameObject.layer = LayerMask.NameToLayer("Placed");
                    if (isBomb)
                        transform.GetChild(1).gameObject.GetComponent<Rigidbody>().isKinematic = false;
                }
                else
                {
                    foreach (Rigidbody item in GetComponentsInChildren<Rigidbody>())
                        item.gameObject.layer = LayerMask.NameToLayer("Placed");
                    foreach (MeshCollider item in GetComponentsInChildren<MeshCollider>())
                        item.gameObject.layer = LayerMask.NameToLayer("Placed");
                }
                StartCoroutine(NewTurn(true));
                switch (fallSound)
                {
                    case PieceSound.Basic:
                        DJ.instance.PlaySound(DJ.SoundsKeyWord.Fall);
                        break;
                    case PieceSound.Piano:
                        DJ.instance.PlaySound(DJ.SoundsKeyWord.Piano);
                        break;
                    case PieceSound.Xylophone:
                        DJ.instance.PlaySound(DJ.SoundsKeyWord.Xylophone);
                        break;
                    case PieceSound.Ball:
                        DJ.instance.PlaySound(DJ.SoundsKeyWord.Ball);
                        break;
                    case PieceSound.Jelly:
                        DJ.instance.PlaySound(DJ.SoundsKeyWord.Jelly);
                        break;
                    default:
                        Debug.LogError("You can't be here.");
                        break;
                }
            }
        }
        else
        {
            if (!soundGroundDone)
            {
                soundGroundDone = true;
                switch (fallSound)
                {
                    case PieceSound.Basic:
                        DJ.instance.PlaySound(DJ.SoundsKeyWord.Ground);
                        break;
                    case PieceSound.Piano:
                        DJ.instance.PlaySound(DJ.SoundsKeyWord.Piano);
                        break;
                    case PieceSound.Xylophone:
                        DJ.instance.PlaySound(DJ.SoundsKeyWord.Xylophone);
                        break;
                    case PieceSound.Ball:
                        DJ.instance.PlaySound(DJ.SoundsKeyWord.Ball);
                        break;
                    case PieceSound.Jelly:
                        DJ.instance.PlaySound(DJ.SoundsKeyWord.Jelly);
                        break;
                    default:
                        Debug.LogError("You can't be here.");
                        break;
                }
            }
            if (!deathFXDone)
            {
                DJ.instance.PlaySound(DJ.SoundsKeyWord.Confettis);
                Instantiate(GameManager.instance.deathFX, collision.GetContact(0).point+new Vector3(0,.5f,0), GameManager.instance.deathFX.transform.rotation);
                deathFXDone = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (toPlace && other.gameObject.layer != LayerMask.NameToLayer("ToPlace"))
        {
            DJ.instance.PlaySound(DJ.SoundsKeyWord.Impossible);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (toPlace && other.gameObject.layer != LayerMask.NameToLayer("ToPlace"))
        {
            GameManager.instance.movingScript.canDrop = false;
            if (meshRender.materials[0] != GameManager.instance.cantDropMaterial)
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

    public void OnTriggerExit(Collider other)
    {
        if (toPlace && other.gameObject.layer != LayerMask.NameToLayer("ToPlace"))
        {
            GameManager.instance.movingScript.canDrop = true;
            meshRender.materials = pieceOriginalMaterials;
        }
    }

    public enum PieceSound
    {
        Basic, Piano, Xylophone, Ball, Jelly
    }
}
