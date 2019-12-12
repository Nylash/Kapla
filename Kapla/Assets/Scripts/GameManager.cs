﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class GameManager : MonoBehaviour
{
#pragma warning disable 0649
    [Header("GAME CONFIGURATION")]
    [SerializeField] GameObject managerPrefab;
    [SerializeField] public GameObject dropFX;
    [SerializeField] public GameObject deathFX;
    [SerializeField] Vector3 offsetSpawn = new Vector3(0,4,0);
    [SerializeField] int timeBeforeAutoDrop = 16;
    [Header("SHAKE SCREEN CONFIGURATION")]
    [SerializeField] float magnitude;
    [SerializeField] float roughness;
    [SerializeField] float fadeIn;
    [SerializeField] float fadeOut;
#pragma warning restore 0649

    [Header("SCRIPT INFORMATIONS")]
    public Material cantDropMaterial;
    public bool defeat;
    public PlayerInputs lastPlayer;
    public List<GameObject> AllPieces = new List<GameObject>();
    public GameObject guidePrefab;
    public bool dropping;
    public bool shaking;
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
    float timer;
    bool timerStopped;
    int activePlayer;
    GameObject camObject;
    float originalCamZoom;
    bool gameStarted;

    TextMeshProUGUI playerText;
    TextMeshProUGUI timerText;
    TextMeshProUGUI playerTurn;
    Animator bannerTurnAnimator;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        if(PlayersManager.instance == null)
        {
            GameObject manager = Instantiate(managerPrefab);
            manager.GetComponent<PlayersManager>().DebugMode();
        }
    }

    private void Start()
    {
        movingScript = GetComponent<MovingObject>();
        distributorScript = GetComponent<PiecesDistributor>();
        center = GameObject.FindGameObjectWithTag("Center");
        playerText = GameObject.FindGameObjectWithTag("PlayerText").GetComponent<TextMeshProUGUI>();
        timerText = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();
        camObject = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        bannerTurnAnimator = GameObject.FindGameObjectWithTag("PlayerTurn").GetComponent<Animator>();
        playerTurn = GameObject.FindGameObjectWithTag("PlayerTurn").GetComponentInChildren<TextMeshProUGUI>();
        originalCamZoom = camObject.transform.localPosition.z;
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (!defeat && gameStarted)
        {
            center.transform.position = Vector3.Lerp(center.transform.position, new Vector3(0, GetMaxHigh(), 0), Time.deltaTime);
            camObject.transform.localPosition = new Vector3(0, 0, Mathf.Lerp(camObject.transform.localPosition.z, GetMaxWidth(), Time.deltaTime));
            if (!timerStopped)
            {
                timer -= Time.deltaTime;
                timerText.text = ((int)timer).ToString();
                if ((int)timer == 0)
                    movingScript.DropPiece();
            }
            else
                timerText.text = "";
            if (dropping)
                center.transform.localEulerAngles = Vector3.Lerp(center.transform.localEulerAngles, new Vector3(20, center.transform.localEulerAngles.y, 0), Time.deltaTime);
        }
        if(defeat)
            center.transform.position = Vector3.Lerp(center.transform.position, new Vector3(0, GetMaxHigh(), 0), Time.deltaTime);
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
            if (currentPiece.GetComponent<Piece>().isTrain)
                movingScript.currentRigidbody = currentPiece.transform.GetChild(0).gameObject.GetComponent<Rigidbody>();
            else
                movingScript.currentRigidbody = currentPiece.GetComponentInChildren<Rigidbody>();
            movingScript.arrowGuideObject.transform.localPosition = new Vector3(0, 0, currentPiece.GetComponent<Piece>().arrowGuideOffset);
        }
    }

    IEnumerator StartGame()
    {
        timerStopped = true;
        playerText.text = "P1";
        activePlayer = 0;
        PlayersManager.instance.players[activePlayer].CleanInputs();
        playerTurn.text = PlayersManager.instance.players[activePlayer].ID + " it's your turn !";
        bannerTurnAnimator.SetTrigger("Launch");
        yield return new WaitForSeconds(1.5f);
        gameStarted = true;
        PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.HisTurn;
        InstantiateNewPiece();
    }

    public void SetLastPlayer()
    {
        timerStopped = true;
        PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.NotHisTurn;
        PlayersManager.instance.players[activePlayer].CleanInputs();
        lastPlayer = PlayersManager.instance.players[activePlayer];
    }

    public IEnumerator ChangePlayer()
    {
        if (!defeat)
        {
            if (activePlayer == PlayersManager.instance.players.Count - 1)
                activePlayer = 0;
            else
                activePlayer++;
            playerText.text = PlayersManager.instance.players[activePlayer].ID;
            playerTurn.text = PlayersManager.instance.players[activePlayer].ID + " it's your turn !";
            bannerTurnAnimator.SetTrigger("Launch");
        }
        yield return new WaitForSeconds(1.5f);
        PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.HisTurn;
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
        }
        if (movingScript.currentPiece && !defeat)
        {
            return (movingScript.currentPiece.transform.position.y + max) / 2;
        }
        return max;
    }

    float GetMaxWidth()
    {
        float max = 0;
        if(AllPieces.Count != 0)
        {
            foreach (GameObject item in AllPieces)
            {
                if (item.transform.position.x > max)
                    max = item.transform.position.x;
                if (item.transform.position.z > max)
                    max = item.transform.position.z;
            }
        }
        return -max + originalCamZoom;
    }

    public void Restart()
    {
        foreach(PlayerInputs player in PlayersManager.instance.players)
        {
            player.state = PlayerInputs.PlayerState.NotHisTurn;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator Shake()
    {
        if (!shaking)
        {
            shaking = true;
            CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeIn, fadeOut);
            yield return new WaitForSeconds(fadeIn + fadeOut);
            shaking = false;
        }
        else
            yield break;
    }

    public IEnumerator BigShake()
    {
        if (!shaking)
        {
            shaking = true;
            CameraShaker.Instance.ShakeOnce(magnitude*4, roughness*2, fadeIn*2, fadeOut*2);
            yield return new WaitForSeconds(fadeIn + fadeOut);
            shaking = false;
        }
        else
            yield break;
    }
}
