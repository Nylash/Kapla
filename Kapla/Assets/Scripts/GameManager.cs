using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
#pragma warning disable 0649
    [Header("GAME CONFIGURATION")]
    [SerializeField] Vector3 offsetSpawn = new Vector3(0,4,0);
    [SerializeField] int timeBeforeAutoDrop = 16;
#pragma warning restore 0649

    [Header("SCRIPT INFORMATIONS")]
    public Material cantDropMaterial;
    public bool defeat;
    public string lastPlayer;
    public List<GameObject> AllPieces = new List<GameObject>();
    public GameObject collumnPrefab;

    [HideInInspector]
    public MovingObject movingScript;
    [HideInInspector]
    public PiecesDistributor distributorScript;
    [HideInInspector]
    public static GameManager instance = null;

    GameObject center;
    TextMeshProUGUI playerText;
    TextMeshProUGUI timerText;

    float timer;
    bool timerStopped;

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
        timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();

        playerText.text = "P1";
        InstantiateNewPiece();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        center.transform.position = Vector3.Lerp(center.transform.position, new Vector3(0, GetMaxHigh(), 0), Time.deltaTime);
        if (!timerStopped && !defeat)
        {
            timer -= Time.deltaTime;
            timerText.text = ((int)timer).ToString();
            if ((int)timer == 0)
                StartCoroutine(movingScript.DropPiece());
        }
        else
            timerText.text = "";
    }

    public void InstantiateNewPiece()
    {
        timer = timeBeforeAutoDrop;
        timerStopped = false;
        GameObject piece = distributorScript.GetRandomPiece();
        if (piece)
        {
            GameObject currentPiece = GameObject.Instantiate(piece, center.transform.position + offsetSpawn, piece.transform.rotation);
            movingScript.currentPiece = currentPiece;
            movingScript.currentRigidbody = currentPiece.GetComponentInChildren<Rigidbody>();
        }
    }

    public void ChangePlayer()
    {
        timerStopped = true;
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

    float GetMaxHigh()
    {
        float max = 0;
        if(AllPieces.Count != 0)
        {
            foreach (GameObject item in AllPieces)
            {
                if (item.transform.position.y > max)
                    max = item.transform.position.y;
            }
            return max;
        }
        return 0;
    }
}
