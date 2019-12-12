using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;
    public float power = 10.0f;
    public float radius = 10.0f;
    public float upforce = 1.0f;
    public List<Rigidbody> rigidList = new List<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BombTrigger")
        {
            print("fdp");
            Detonate();
        }
    }

    void Detonate()
    {
        /*Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider item in colliders)
        {
            if (!rigidList.Contains(item.transform.parent.gameObject.GetComponent<Rigidbody>()))
                rigidList.Add(item.transform.parent.gameObject.GetComponent<Rigidbody>());
        }
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
        }*/
    }

}
