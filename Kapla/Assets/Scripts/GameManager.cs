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
    
    public List<GameObject> AllPieces = new List<GameObject>();
    public GameObject collumnPrefab;
    [Header("INPUTS DATA")]
    public Vector2 movementDirection;
    public Vector2 cameraMovementPad;
    public Vector2 cameraMovementMouse;
    public float up;
    public float down;
    public bool cameraCanMove;

    [HideInInspector]
    public MovingObject movingScript;
    [HideInInspector]
    public PiecesDistributor distributorScript;
    [HideInInspector]
    public static GameManager instance = null;
    public float cameraAngle;

    GameObject center;
    TextMeshProUGUI playerText;
    TextMeshProUGUI timerText;

    float timer;
    bool timerStopped;
    public int activePlayer;
    public PlayerInputs lastPlayer;

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

        InstantiateNewPiece();
        playerText.text = "P1";
        activePlayer = 0;
        PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.HisTurn;
        PlayersManager.instance.players[activePlayer].CleanInputs();
    }

    private void Update()
    {
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
            movingScript.currentRigidbody = currentPiece.GetComponent<Rigidbody>();
        }
    }

    public void ChangePlayer()
    {
        timerStopped = true;
        PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.NotHisTurn;
        PlayersManager.instance.players[activePlayer].CleanInputs();
        lastPlayer = PlayersManager.instance.players[activePlayer];
        if (activePlayer == PlayersManager.instance.players.Count - 1)
            activePlayer = 0;
        else
            activePlayer++;
        PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.HisTurn;
        playerText.text = PlayersManager.instance.players[activePlayer].ID;
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

    public void Restart()
    {
        foreach(PlayerInputs player in PlayersManager.instance.players)
        {
            player.state = PlayerInputs.PlayerState.NotHisTurn;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
