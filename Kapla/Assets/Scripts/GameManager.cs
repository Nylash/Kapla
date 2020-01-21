using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using EZCameraShake;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
#pragma warning disable 0649
    [Header("GAME CONFIGURATION")]
    [SerializeField] GameObject managerPrefab;
    [SerializeField] GameObject DjPrefab;
    [SerializeField] public GameObject dropFX;
    [SerializeField] public GameObject deathFX;
    [SerializeField] Vector3 offsetSpawn = new Vector3(0,4,0);
    public int timeBeforeAutoDrop;
    public float invicibleTime = 1.5f;
    public GameObject explosionFX;
    public GameObject pauseMenu;
    public bool inPause;
    [Header("SHAKE SCREEN CONFIGURATION")]
    [SerializeField] float magnitude;
    [SerializeField] float roughness;
    [SerializeField] float fadeIn;
    [SerializeField] float fadeOut;
#pragma warning restore 0649

    [Header("SCRIPT INFORMATIONS")]
    public Material cantDropMaterial;
    public bool defeat;
    public string lastPlayer;
    public string newPlayer;
    public List<GameObject> AllPieces = new List<GameObject>();
    public GameObject guidePrefab;
    public bool dropping;
    public bool shaking;
    public bool oneController;
    public int activePlayer;
    public GameObject replayButtons;
    [Header("INPUTS DATA")]
    public Vector2 movementDirection;
    public Vector2 cameraMovementPad;
    public Vector2 cameraMovementMouse;
    public float up;
    public float down;
    public bool cameraCanMove;
    [Header("PLAYERS COLORS")]
    public Color p1Color;
    public Color p2Color;
    public Color p3Color;
    public Color p4Color;
    public Color p5Color;
    public Color p6Color;
    public Material p1mat;
    public Material p2mat;
    public Material p3mat;
    public Material p4mat;
    public Material p5mat;
    public Material p6mat;

    [HideInInspector]
    public MovingObject movingScript;
    [HideInInspector]
    public PiecesDistributor distributorScript;
    [HideInInspector]
    public static GameManager instance = null;
    [HideInInspector]
    public float cameraAngle;

    GameObject center;
    [HideInInspector]
    public float timer;
    [HideInInspector]
    public bool timerStopped;
    GameObject camObject;
    float originalCamZoom;
    bool gameStarted;
    bool alarmPlaying;

    TextMeshProUGUI playerText;
    TextMeshProUGUI playerTurn;
    Image timerImg;
    Animator bannerTurnAnimator;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        if (OneControllerManager.instance != null)
            oneController = true;
        else if (PlayersManager.instance != null)
            oneController = false;
        else
        {
            GameObject manager = Instantiate(managerPrefab);
            manager.GetComponent<OneControllerManager>().DebugMode();
            oneController = true;
        }
        if (DJ.instance == null)
            Instantiate(DjPrefab);
    }

    private void Start()
    {
        movingScript = GetComponent<MovingObject>();
        distributorScript = GetComponent<PiecesDistributor>();
        center = GameObject.FindGameObjectWithTag("Center");
        playerText = GameObject.FindGameObjectWithTag("PlayerText").GetComponent<TextMeshProUGUI>();
        timerImg = GameObject.FindGameObjectWithTag("Timer").GetComponent<Image>();
        camObject = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        bannerTurnAnimator = GameObject.FindGameObjectWithTag("PlayerTurn").GetComponent<Animator>();
        playerTurn = GameObject.FindGameObjectWithTag("PlayerTurnText").GetComponent<TextMeshProUGUI>();
        originalCamZoom = camObject.transform.localPosition.z;
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (!defeat && gameStarted)
        {
            center.transform.position = Vector3.Lerp(center.transform.position, new Vector3(0, GetMaxHigh()-2, 0), Time.deltaTime);
            camObject.transform.localPosition = new Vector3(0, 0, Mathf.Lerp(camObject.transform.localPosition.z, GetMaxWidth(), Time.deltaTime));
            if (!timerStopped)
            {
                timer -= Time.deltaTime;
                float t = timer / timeBeforeAutoDrop;
                timerImg.fillAmount = (timer / timeBeforeAutoDrop) - Mathf.Lerp(0.03324204f, 0,t);
                if ((int)timer == 0)
                {
                    movingScript.DropPiece();
                    alarmPlaying = false;
                } 
                if ((int)timer == 6 && !alarmPlaying)
                {
                    alarmPlaying = true;
                    DJ.instance.PlaySound(DJ.SoundsKeyWord.Warning);
                }   
            }
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
        playerText.color = p1Color;
        activePlayer = 0;
        if (!oneController)
            PlayersManager.instance.players[activePlayer].CleanInputs();
        playerTurn.text = "P1";
        playerTurn.color = p1Color;
        bannerTurnAnimator.SetTrigger("Launch");
        yield return new WaitForSeconds(1.5f);
        gameStarted = true;
        if(!oneController)
            PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.HisTurn;
        else
            OneControllerManager.instance.canPlay = true;
        InstantiateNewPiece();
    }

    public void Pause()
    {
        inPause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        EventSystem.current.SetSelectedGameObject(pauseMenu.transform.GetChild(0).gameObject);
        if (oneController)
            OneControllerManager.instance.canPlay = false;
        else
            PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.NotHisTurn;
        InputSystem.ResetHaptics();
    }
    
    public void UnPause()
    {
        inPause = false;
        pauseMenu.GetComponent<PauseMenu>().ResetFont();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        if (oneController)
            OneControllerManager.instance.canPlay = true;
        else
            PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.HisTurn;
    }

    public void RestartButton()
    {
        if (oneController)
            OneControllerManager.instance.Restart();
        else
            PlayersManager.instance.Restart();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLobby()
    {
        if (oneController)
            OneControllerManager.instance.DestroyPlayers();
        else
            PlayersManager.instance.DestroyPlayers();
        DJ.instance.PlayMusic(DJ.MusicKeyWork.Menu);
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");   
    }

    public void ValidationSound()
    {
        DJ.instance.ValidationSound();
    }

    public void SetLastPlayer()
    {
        timerStopped = true;
        if (!oneController)
        {
            PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.NotHisTurn;
            PlayersManager.instance.players[activePlayer].CleanInputs();
            lastPlayer = PlayersManager.instance.players[activePlayer].ID;
            if (activePlayer == PlayersManager.instance.players.Count - 1)
                newPlayer = PlayersManager.instance.players[0].ID;
            else
                newPlayer = PlayersManager.instance.players[activePlayer+1].ID;
        }
        else
        {
            lastPlayer = OneControllerManager.instance.players[activePlayer];
            OneControllerManager.instance.canPlay = false;
            if (activePlayer == OneControllerManager.instance.players.Count - 1)
                newPlayer = OneControllerManager.instance.players[0];
            else
                newPlayer = OneControllerManager.instance.players[activePlayer + 1];
        }
    }

    public IEnumerator ChangePlayer()
    {
        if (!defeat)
        {
            if (!oneController)
            {
                if (activePlayer == PlayersManager.instance.players.Count - 1)
                    activePlayer = 0;
                else
                    activePlayer++;
                switch (PlayersManager.instance.players[activePlayer].ID)
                {
                    case "P1":
                        playerText.text = "P1";
                        playerText.color = p1Color;
                        playerTurn.text = "P1";
                        playerTurn.color = p1Color;
                        break;
                    case "P2":
                        playerText.text = "P2";
                        playerText.color = p2Color;
                        playerTurn.text = "P2";
                        playerTurn.color = p2Color;
                        break;
                    case "P3":
                        playerText.text = "P3";
                        playerText.color = p3Color;
                        playerTurn.text = "P3";
                        playerTurn.color = p3Color;
                        break;
                    case "P4":
                        playerText.text = "P4";
                        playerText.color = p4Color;
                        playerTurn.text = "P4";
                        playerTurn.color = p4Color;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (activePlayer == OneControllerManager.instance.players.Count - 1)
                    activePlayer = 0;
                else
                    activePlayer++;
                switch (OneControllerManager.instance.players[activePlayer])
                {
                    case "P1":
                        playerText.text = "P1";
                        playerText.color = p1Color;
                        playerTurn.text = "P1";
                        playerTurn.color = p1Color;
                        break;
                    case "P2":
                        playerText.text = "P2";
                        playerText.color = p2Color;
                        playerTurn.text = "P2";
                        playerTurn.color = p2Color;
                        break;
                    case "P3":
                        playerText.text = "P3";
                        playerText.color = p3Color;
                        playerTurn.text = "P3";
                        playerTurn.color = p3Color;
                        break;
                    case "P4":
                        playerText.text = "P4";
                        playerText.color = p4Color;
                        playerTurn.text = "P4";
                        playerTurn.color = p4Color;
                        break;
                    case "P5":
                        playerText.text = "P5";
                        playerText.color = p5Color;
                        playerTurn.text = "P5";
                        playerTurn.color = p5Color;
                        break;
                    case "P6":
                        playerText.text = "P6";
                        playerText.color = p6Color;
                        playerTurn.text = "P6";
                        playerTurn.color = p6Color;
                        break;
                    default:
                        break;
                }
            }
            bannerTurnAnimator.SetTrigger("Launch");
            DJ.instance.PlaySound(DJ.SoundsKeyWord.Turn);
        }
        yield return new WaitForSeconds(1.5f);
        if (!oneController)
            PlayersManager.instance.players[activePlayer].state = PlayerInputs.PlayerState.HisTurn;
        else
            OneControllerManager.instance.canPlay = true;
    }

    float GetMaxHigh()
    {
        //PlayersManager.instance.players[0];
        float max = 0;
        if(AllPieces.Count != 0)
        {
            foreach (GameObject item in AllPieces)
            {
                if (item.GetComponent<Piece>().isTrain)
                {
                    Vector3 tmp = item.transform.InverseTransformPoint(new Vector3(0, item.transform.position.y, 0));
                    if (tmp.y > max)
                        max = tmp.y;
                }
                else
                {
                    if (item.transform.position.y > max)
                        max = item.transform.position.y;
                }
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
        if (!oneController)
        {
            foreach (PlayerInputs player in PlayersManager.instance.players)
                player.state = PlayerInputs.PlayerState.NotHisTurn;
        }
        else
            OneControllerManager.instance.canPlay = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public Color GetPlayerColor(string player)
    {
        switch (player)
        {
            case "P1":
                return p1Color;
            case "P2":
                return p2Color;
            case "P3":
                return p3Color;
            case "P4":
                return p4Color;
            case "P5":
                return p5Color;
            case "P6":
                return p6Color;
            default:
                return Color.white;
        }
    }

    public Material GetPlayerMaterial(string player)
    {
        switch (player)
        {
            case "P1":
                return p1mat;
            case "P2":
                return p2mat;
            case "P3":
                return p3mat;
            case "P4":
                return p4mat;
            case "P5":
                return p5mat;
            case "P6":
                return p6mat;
            default:
                return null;
        }
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
