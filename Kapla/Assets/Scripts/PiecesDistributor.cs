using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesDistributor : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] List<Prob> TypeProp;
    [Header("PIECES OBJECT")]
    [SerializeField] List<GameObject> NeutralPieces;
    [SerializeField] List<GameObject> GummyPieces;
    [SerializeField] List<GameObject> StickyPieces;
#pragma warning restore 0649

    public List<Piece.PieceType> IDList = new List<Piece.PieceType>();

    int totalTypeProb;

    private void Awake()
    {
        foreach (Prob item in TypeProp)
        {
            totalTypeProb += item.prob;
        }
        if (totalTypeProb != 100)
            Debug.LogError("Total of probability, for PieceType, is not egal to 100. (=" + totalTypeProb + ")");
        foreach (Prob item in TypeProp)
        {
            for (int i = 0; i < item.prob; i++)
            {
                IDList.Add(item.ID);
            }
        }
    }

    public GameObject GetRandomPiece()
    {
        switch (IDList[Random.Range(0,IDList.Count)])
        {
            case Piece.PieceType.neutral:
                return NeutralPieces[Random.Range(0,NeutralPieces.Count)];
            case Piece.PieceType.gummy:
                return GummyPieces[Random.Range(0, GummyPieces.Count)];
            case Piece.PieceType.sticky:
                return StickyPieces[Random.Range(0, StickyPieces.Count)];
            default:
                Debug.LogError("You can't be there.");
                return null;
        }
    }

    [System.Serializable]
    public struct Prob
    {
        public Piece.PieceType ID;
        [Range(0, 100)] public int prob;
    }
}
