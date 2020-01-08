using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInputs : MonoBehaviour
{
    public PlayerState state;
    public string ID;

    Vector2 movementDirection;
    Vector2 cameraMovementPad;
    Vector2 cameraMovementMouse;
    float up;
    float down;
    bool cameraCanMove;

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

    void OnUpTrigger(InputValue value)
    {
        if (state == PlayerState.HisTurn)
        {
            up = value.Get<float>();
        }
    }

    void OnUpTriggerRelease()
    {
        if (state == PlayerState.HisTurn)
        {
            up = 0;
        }
    }

    void OnDownTrigger(InputValue value)
    {
        if (state == PlayerState.HisTurn)
        {
            down = value.Get<float>();
        }
    }

    void OnDownTriggerRelease()
    {
        if (state == PlayerState.HisTurn)
        {
            down = 0;
        }
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

    void OnRotZ()
    {
        if (state == PlayerState.HisTurn)
          GameManager.instance.movingScript.RotZ();
    }

    void OnDrop()
    {
        if (state == PlayerState.HisTurn)
            GameManager.instance.movingScript.Drop();
    }

    void OnValidateChoice()
    {
        if (PlayersManager.instance.inLobby && PlayersManager.instance.players.Count >= 2)
            PlayersManager.instance.LoadGame();
    }

    void OnBack()
    {
        if (PlayersManager.instance.inLobby)
            SceneManager.LoadScene("Lobby");      
    }

    void OnRestart()
    {
        if (!PlayersManager.instance.inLobby)
        {
            if (state == PlayerState.HisTurn || GameManager.instance.defeat)
                GameManager.instance.Restart();
        }
        
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
