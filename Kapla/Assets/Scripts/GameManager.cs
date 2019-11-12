using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] Vector3 offsetSpawn = new Vector3(0,5,0);
#pragma warning restore 0649

    GameObject center;
    TextMeshProUGUI playerText;

    public Material canDropMaterial;
    public bool defeat;
    public string lastPlayer;

    [HideInInspector]
    public MovingObject movingScript;
    [HideInInspector]
    public PiecesDistributor distributorScript;
    [HideInInspector]
    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        movingScript = GetComponent<MovingObject>();
        distributorScript = GetComponent<PiecesDistributor>();
        center = GameObject.FindGameObjectWithTag("Center");
        playerText = GameObject.FindGameObjectWithTag("PlayerText").GetComponent<TextMeshProUGUI>();

        playerText.text = "P1";
        InstantiateNewPiece();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void InstantiateNewPiece()
    {
        GameObject piece = distributorScript.GetRandomPiece();
        if (piece)
        {
            GameObject currentPiece = GameObject.Instantiate(piece, center.transform.position + offsetSpawn, piece.transform.rotation);
            movingScript.currentPiece = currentPiece;            
        }
    }

    public void ChangePlayer()
    {
        switch (playerText.text)
        {
            case "P1":
                playerText.text = "P2";
                lastPlayer = "P1";
                break;
            case "P2":
                playerText.text = "P1";
                lastPlayer = "P2";
                break;
            default:
                Debug.LogError("You shouldn't be here.");
                break;
        }
    }
}
