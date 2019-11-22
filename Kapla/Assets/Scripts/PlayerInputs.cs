using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    Controls controls;

    public Vector2 movementDirection;
    public Vector2 cameraMovementPad;
    public Vector2 cameraMovementMouse;
    public float up;
    public float down;
    public bool cameraCanMove;

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
    }

    private void Update()
    {
        GameManager.instance.movementDirection = movementDirection;
        GameManager.instance.cameraMovementPad = cameraMovementPad;
        GameManager.instance.cameraMovementMouse = cameraMovementMouse;
        GameManager.instance.up = up;
        GameManager.instance.down = down;
        GameManager.instance.cameraCanMove = cameraCanMove;
    }

    void RotX()
    {
        GameManager.instance.movingScript.RotX();
    }

    void RotY()
    {
        GameManager.instance.movingScript.RotY();
    }

    void RotZ()
    {
        GameManager.instance.movingScript.RotZ();
    }

    void Drop()
    {
        GameManager.instance.movingScript.Drop();
    }

    void Restart()
    {
        GameManager.instance.Restart();
    }

    void SwitchMovementSystem()
    {
        GameManager.instance.movingScript.SwitchMovementSystem();
    }
}
