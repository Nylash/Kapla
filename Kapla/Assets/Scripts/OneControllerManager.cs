using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class OneControllerManager : MonoBehaviour
{
    public GameObject controlsPanel;
    public static OneControllerManager instance = null;
    public List<string> players = new List<string>();
    public bool inLobby = true;
    public bool canPlay = false;

    Vector2 movementDirection;
    Vector2 cameraMovementPad;
    Vector2 cameraMovementMouse;
    float up;
    float down;
    bool cameraCanMove;
    List<string> stockPlayers = new List<string>();

    Controls controls;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        controls = new Controls();

        controls.Gameplay.Move.performed += ctx => movementDirection = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => movementDirection = Vector2.zero;

        controls.Gameplay.CameraMovementPad.performed += ctx => cameraMovementPad = ctx.ReadValue<Vector2>();
        controls.Gameplay.CameraMovementPad.canceled += ctx => cameraMovementPad = Vector2.zero;

        controls.Gameplay.CameraMovementMouse.performed += ctx => cameraMovementMouse = ctx.ReadValue<Vector2>();
        controls.Gameplay.CameraMovementMouse.canceled += ctx => cameraMovementMouse = Vector2.zero;

        controls.Gameplay.UpTrigger.performed += ctx => up = ctx.ReadValue<float>();
        controls.Gameplay.UpTrigger.canceled += ctx => up = 0;

        controls.Gameplay.DownTrigger.performed += ctx => down = ctx.ReadValue<float>();
        controls.Gameplay.DownTrigger.canceled += ctx => down = 0;

        controls.Gameplay.CameraCanMove.started += ctx => cameraCanMove = true;
        controls.Gameplay.CameraCanMove.canceled += ctx => cameraCanMove = false;

        controls.Gameplay.RotX.started += ctx => RotX();
        controls.Gameplay.RotY.started += ctx => RotY();
        controls.Gameplay.RotZ.started += ctx => RotZ();
        controls.Gameplay.Drop.started += ctx => Drop();
        controls.Gameplay.Pause.started += ctx => Pause();
        controls.Gameplay.ValidateChoice.started += ctx => ValidateChoice();
        controls.Gameplay.Back.started += ctx => Back();
        controls.Gameplay.Controls.started += ctx => ControlsPanel();
    }

    private void Start()
    {
        //temp to remove unity's debug updater which crashes with new input
        GameObject go = GameObject.Find("[Debug Updater]");
        if (go != null) DestroyImmediate(go);
    }

    private void Update()
    {
        if (canPlay)
        {
            GameManager.instance.movementDirection = movementDirection;
            GameManager.instance.up = up;
            GameManager.instance.down = down;
            if (!GameManager.instance.dropping)
            {
                GameManager.instance.cameraMovementPad = cameraMovementPad;
                GameManager.instance.cameraMovementMouse = cameraMovementMouse;
                GameManager.instance.cameraCanMove = cameraCanMove;
            }
        }
    }

    void RotX()
    {
        if (canPlay)
            GameManager.instance.movingScript.RotX();
    }

    void RotY()
    {
        if (canPlay)
            GameManager.instance.movingScript.RotY();
    }

    void RotZ()
    {
        if (canPlay)
            GameManager.instance.movingScript.RotZ();
    }

    void Drop()
    {
        if (canPlay)
            GameManager.instance.movingScript.Drop();
    }

    void ValidateChoice()
    {
        if (OneControllerManager.instance.inLobby && !controlsPanel.activeSelf)
        {
            FillPlayersList(GameObject.FindObjectOfType<PlayersNumberSelection>().currentPlayersNumber);
            stockPlayers.AddRange(players);
            OneControllerManager.instance.LoadGame();
        }
    }

    void Pause()
    {
        if (!inLobby && GameManager.instance)
        {
            if (!GameManager.instance.defeat)
            {
                if (!GameManager.instance.inPause)
                    GameManager.instance.Pause();
                else
                    GameManager.instance.UnPause();
            }
        } 
    }

    public void DestroyPlayers()
    {
        Destroy(gameObject);
    }

    public void Restart()
    {
        players.Clear();
        players.AddRange(stockPlayers);
        GameManager.instance.Restart();
    }

    void LoadGame()
    {
        DJ.instance.PlaySound(DJ.SoundsKeyWord.Validation);
        inLobby = false;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Room");
    }

    void Back()
    {
        if (inLobby && !controlsPanel.activeSelf)
        {
            DJ.instance.PlaySound(DJ.SoundsKeyWord.Validation);
            SceneManager.LoadScene("Lobby");
        }  
    }

    void ControlsPanel()
    {
        if (inLobby)
            controlsPanel.SetActive(!controlsPanel.activeSelf);
    }

    void FillPlayersList(int number)
    {
        for (int i = 0; i < number; i++)
        {
            players.Add("P" + (i + 1));
        }
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    public IEnumerator MakeRumble(float leftMotor, float rightMotor, float duration)
    {
        if(Gamepad.current != null)
        {
            Gamepad.current.SetMotorSpeeds(leftMotor, rightMotor);
            yield return new WaitForSeconds(duration);
            for (int i = 0; i < Gamepad.all.Count; i++)
            {
                Gamepad.all[i].SetMotorSpeeds(0, 0);
            }
        }
    }

    public void DebugMode()
    {
        inLobby = false;
        players.Add("P1");
        players.Add("P2");
        players.Add("P3");
        stockPlayers.AddRange(players);
        DontDestroyOnLoad(gameObject);
    }
}
