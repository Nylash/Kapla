using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterials : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] Material[] materialsRemplacingFirst;
    [SerializeField] Material[] materialsRemplacingSecond;
    [SerializeField] Material[] materialsRemplacingThird;
    [SerializeField] Material[] materialsRemplacingFourth;
    [SerializeField] Material[] materialsRemplacingFifth;
    [SerializeField] Material[] materialsRemplacingSixth;
    [SerializeField] Material[] materialsRemplacingSeventh;
#pragma warning restore 0649
    List<Material[]> allMaterials = new List<Material[]>();
    MeshRenderer meshRender;

    private void Awake()
    {
        allMaterials.Add(materialsRemplacingFirst);
        allMaterials.Add(materialsRemplacingSecond);
        allMaterials.Add(materialsRemplacingThird);
        allMaterials.Add(materialsRemplacingFourth);
        allMaterials.Add(materialsRemplacingFifth);
        allMaterials.Add(materialsRemplacingSixth);
        allMaterials.Add(materialsRemplacingSeventh);
        meshRender = GetComponent<MeshRenderer>();
        Material[] tmp = new Material[meshRender.materials.Length];
        for (int i = 0; i < tmp.Length; i++)
        {
            tmp[i] = allMaterials[i][Random.Range(0, allMaterials[i].Length)];
        }
        meshRender.materials = tmp;
        Destroy(this);
    }
}
