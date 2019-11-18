using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceProjection : MonoBehaviour
{
    public bool onTrigger;

    private void Update()
    {
        if (!onTrigger)
        {
            if(transform.position.y > 0 )
                transform.Translate(-Vector3.up * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("ToPlace"))
        {
            onTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("ToPlace"))
        {
            onTrigger = true;
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("ToPlace"))
        {
            onTrigger = false;
        }
    }
}
