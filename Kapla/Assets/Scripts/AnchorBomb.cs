using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorBomb : MonoBehaviour
{
    public GameObject bomb;

    private void Update()
    {
        transform.position = bomb.transform.position + bomb.transform.up;
        transform.rotation = bomb.transform.rotation;
    }
}
