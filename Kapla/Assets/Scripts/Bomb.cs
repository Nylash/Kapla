using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float power = 150;
    public float radius = 10.0f;
    public float upforce = 1.0f;
    public List<Rigidbody> rigidList = new List<Rigidbody>();
    public List<Piece> piecesList = new List<Piece>();

    public void Detonate()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider item in colliders)
        {
            if(item.attachedRigidbody)
            {
                if (!rigidList.Contains(item.attachedRigidbody))
                {
                    rigidList.Add(item.attachedRigidbody);
                    if (item.attachedRigidbody.GetComponent<TrainRigidbody>())
                    {
                        if (!piecesList.Contains(item.attachedRigidbody.transform.parent.GetComponent<Piece>()))
                            piecesList.Add(item.attachedRigidbody.transform.parent.GetComponent<Piece>());
                    }
                    else
                    {
                        if (item.attachedRigidbody.gameObject.GetInstanceID() != gameObject.GetInstanceID())
                        {
                            if (!piecesList.Contains(item.attachedRigidbody.GetComponent<Piece>()))
                                piecesList.Add(item.attachedRigidbody.GetComponent<Piece>());
                        }                            
                    }
                }
            }
        }
        foreach (Piece item in piecesList)
        {
            item.Explode(power, transform.position, radius, upforce);
        }
        GameManager.instance.AllPieces.Remove(gameObject);
        StartCoroutine(EliminateBomb());
        Instantiate(GameManager.instance.explosionFX, transform.position, transform.rotation);
    }

    IEnumerator EliminateBomb()
    {
        Destroy(GetComponent<Rigidbody>());
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
