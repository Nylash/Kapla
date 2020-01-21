using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaRandomizer : MonoBehaviour
{
#pragma warning disable 0649
    [Header("ARENA PREFABS")]
    [SerializeField] GameObject[] arenaPrefabs;
#pragma warning restore 0649

    private void Awake()
    {
        Instantiate(arenaPrefabs[Random.Range(0, arenaPrefabs.Length)],new Vector3(0,.5f,0), Quaternion.identity);
    }
}
