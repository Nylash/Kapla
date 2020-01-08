﻿using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class SplashScreen : MonoBehaviour
{
    bool splashScreenDone;

    private void Start()
    {
        //temp to remove unity's debug updater which crashes with new input
        GameObject go = GameObject.Find("[Debug Updater]");
        if (go != null) DestroyImmediate(go);
    }

    private void Update()
    {
        if (splashScreenDone)
        {
            if (Gamepad.current != null && Keyboard.current != null)
            {
                if (Keyboard.current.enterKey.ReadValue() > .8f || Gamepad.current.startButton.ReadValue() > .8f)
                    SceneManager.LoadScene("Lobby");
            }
            else if (Gamepad.current == null)
            {
                if (Keyboard.current.enterKey.ReadValue() > .8f)
                    SceneManager.LoadScene("Lobby");
            }
            else
            {
                if (Gamepad.current.startButton.ReadValue() > .8f)
                    SceneManager.LoadScene("Lobby");
            }
        }
    }

    void SplashScreenDone()
    {
        splashScreenDone = true;
    }
}
