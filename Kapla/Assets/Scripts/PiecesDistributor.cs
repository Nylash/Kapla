using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesDistributor : MonoBehaviour
{
#pragma warning disable 0649
    [Header("PIECES OBJECTS")]
    [SerializeField] List<GameObject> construction_EasyToPlace;
    [SerializeField] List<GameObject> noConstruction_EasyToPlace;
    [SerializeField] List<GameObject> construction_HardToPlace;
    [SerializeField] List<GameObject> noConstruction_HardToPlace;
    [Header("PACK CONFIGURATION")]
    [SerializeField] int packSize;
    [SerializeField] int nb_construction_EasyToPlace;
    [SerializeField] int nb_noConstruction_EasyToPlace;
    [SerializeField] int nb_construction_HardToPlace;
    [SerializeField] int nb_noConstruction_HardToPlace;
#pragma warning restore 0649
    List<GameObject> copy_construction_EasyToPlace = new List<GameObject>();
    List<GameObject> copy_noConstruction_EasyToPlace = new List<GameObject>();
    List<GameObject> copy_construction_HardToPlace = new List<GameObject>();
    List<GameObject> copy_noConstruction_HardToPlace = new List<GameObject>();

    List<GameObject> currentPack = new List<GameObject>();
    bool firstPackDone;

    private void Awake()
    {
        if (nb_construction_EasyToPlace + nb_noConstruction_EasyToPlace + nb_construction_HardToPlace + nb_noConstruction_HardToPlace != packSize)
            Debug.LogWarning("Your pack will not have the expected size : Expected " + packSize + " Actual " + (nb_construction_EasyToPlace + nb_noConstruction_EasyToPlace + nb_construction_HardToPlace + nb_noConstruction_HardToPlace));
        copy_construction_EasyToPlace.AddRange(construction_EasyToPlace);
        copy_noConstruction_EasyToPlace.AddRange(noConstruction_EasyToPlace);
        copy_construction_HardToPlace.AddRange(construction_HardToPlace);
        copy_noConstruction_HardToPlace.AddRange(noConstruction_HardToPlace);
        CreateNewPack();
    }

    public GameObject GetRandomPiece()
    {
        if (currentPack.Count > 0)
        {
            GameObject piece = currentPack[Random.Range(0, currentPack.Count)];
            currentPack.Remove(piece);
            if (currentPack.Count == 0)
                CreateNewPack();
            return piece;
        }
        else
        {
            Debug.LogError("You shouldn't be there.");
            return null;
        } 
    }

    void CreateNewPack()
    {
        if (currentPack.Count != 0)
            Debug.LogError("You shouldn't be there.");
        for (int i = 0; i < nb_construction_EasyToPlace; i++)
        {
            GameObject piece = construction_EasyToPlace[Random.Range(0, construction_EasyToPlace.Count)];
            construction_EasyToPlace.Remove(piece);
            currentPack.Add(piece);
        }
        for (int i = 0; i < nb_noConstruction_EasyToPlace; i++)
        {
            GameObject piece = noConstruction_EasyToPlace[Random.Range(0, noConstruction_EasyToPlace.Count)];
            noConstruction_EasyToPlace.Remove(piece);
            currentPack.Add(piece);
        }
        for (int i = 0; i < nb_construction_HardToPlace; i++)
        {
            GameObject piece = construction_HardToPlace[Random.Range(0, construction_HardToPlace.Count)];
            construction_HardToPlace.Remove(piece);
            currentPack.Add(piece);
        }
        for (int i = 0; i < nb_noConstruction_HardToPlace; i++)
        {
            GameObject piece = noConstruction_HardToPlace[Random.Range(0, noConstruction_HardToPlace.Count)];
            noConstruction_HardToPlace.Remove(piece);
            currentPack.Add(piece);
        }
        if (firstPackDone)
        {
            construction_EasyToPlace.Clear();
            noConstruction_EasyToPlace.Clear();
            construction_HardToPlace.Clear();
            noConstruction_HardToPlace.Clear();
            construction_EasyToPlace.AddRange(copy_construction_EasyToPlace);
            noConstruction_EasyToPlace.AddRange(copy_noConstruction_EasyToPlace);
            construction_HardToPlace.AddRange(copy_construction_HardToPlace);
            noConstruction_HardToPlace.AddRange(copy_noConstruction_HardToPlace);
            firstPackDone = false;
        }
        else
            firstPackDone = true;
    }
}
