using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public PlayerState state;
    public string ID;

    public Vector2 movementDirection;
    public Vector2 cameraMovementPad;
    public Vector2 cameraMovementMouse;
    public float up;
    public float down;
    public bool cameraCanMove;

    /*Controls controls;

    private void Awake()
    {
        controls = new Controls();

        controls.Gameplay.Move.performed += ctx => movementDirection = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => movementDirection = Vector2.zero;

        controls.Gameplay.CameraMovementPad.performed += ctx => cameraMovementPad = ctx.ReadValue<Vector2>();
        controls.Gameplay.CameraMovementPad.canceled += ctx => cameraMovementPad = Vector2.zero;

        controls.Gameplay.CameraMovementMouse.performed += ctx => cameraMovementMouse = ctx.ReadValue<Vector2>();
        controls.Gameplay.CameraMovementMouse.canceled += ctx => cameraMovementMouse = Vector2.zero;

        controls.Gameplay.Up.performed += ctx => up = ctx.ReadValue<float>();
        controls.Gameplay.Up.canceled += ctx => up = 0;

        controls.Gameplay.Down.performed += ctx => down = ctx.ReadValue<float>();
        controls.Gameplay.Down.canceled += ctx => down = 0;

        controls.Gameplay.CameraCanMove.started += ctx => cameraCanMove = true;
        controls.Gameplay.CameraCanMove.canceled += ctx => cameraCanMove = false;

        controls.Gameplay.RotX.started += ctx => RotX();
        controls.Gameplay.RotY.started += ctx => RotY();
        controls.Gameplay.RotZ.started += ctx => RotZ();
        controls.Gameplay.Drop.started += ctx => Drop();
        controls.Gameplay.Restart.started += ctx => Restart();
        controls.Gameplay.SwitchMovementSystem.started += ctx => SwitchMovementSystem();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }*/

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(state == PlayerState.HisTurn)
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

    void OnMove(InputValue value)
    {
        if (state == PlayerState.HisTurn)
            movementDirection = value.Get<Vector2>();
    }

    void OnUp(InputValue value)
    {
        if (state == PlayerState.HisTurn)
            up = value.Get<float>();
    }

    void OnDown(InputValue value)
    {
        if (state == PlayerState.HisTurn)
            down = value.Get<float>();
    }

    void OnCameraMovementPad(InputValue value)
    {
        if (state == PlayerState.HisTurn)
            cameraMovementPad = value.Get<Vector2>();
    }

    void OnCameraMovementMouse(InputValue value)
    {
        if (state == PlayerState.HisTurn)
            cameraMovementMouse = value.Get<Vector2>();
    }

    void OnCameraCanMove(InputValue value)
    {
        if (state == PlayerState.HisTurn)
        {
            switch (value.Get<float>())
            {
                case 0:
                    cameraCanMove = false;
                    break;
                case 1:
                    cameraCanMove = true;
                    break;
                default:
                    cameraCanMove = false;
                    Debug.LogError("You shoudln't be there.");
                    break;
            }
        }
    }

    void OnRotX()
    {
        if (state == PlayerState.HisTurn)
            GameManager.instance.movingScript.RotX();
    }

    void OnRotY()
    {
        if (state == PlayerState.HisTurn)
            GameManager.instance.movingScript.RotY();
    }

    void OnRotZ(InputValue value)
    {
        if (state == PlayerState.HisTurn)
          GameManager.instance.movingScript.RotZ();
    }

    void OnDrop()
    {
        if (state == PlayerState.HisTurn)
            GameManager.instance.movingScript.Drop();
    }

    void OnMenu()
    {
        if (state == PlayerState.HisTurn)
            GameManager.instance.movingScript.SwitchMovementSystem();
        if (PlayersManager.instance.inLobby)
            PlayersManager.instance.LoadGame();
    }

    void OnRestart()
    { 
        if (state == PlayerState.HisTurn || GameManager.instance.defeat)
            GameManager.instance.Restart();
    }

    public void CleanInputs()
    {
        movementDirection = Vector2.zero;
        cameraMovementPad = Vector2.zero;
        cameraMovementMouse = Vector2.zero;
        up = 0;
        down = 0;
        cameraCanMove = false;
    }

    public enum PlayerState
    {
        NotHisTurn, HisTurn
    }
}
