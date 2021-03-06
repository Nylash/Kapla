﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class EventSystemScript : MonoBehaviour
{
#pragma warning disable 0649
    [Header("COLORS")]
    [SerializeField] Color normalColor;
    [SerializeField] Color highlightColor;
    [Header("OBJECTS")]
    [SerializeField] GameObject oneDetails;
    [SerializeField] GameObject severalDetails;
#pragma warning restore 0649
    GameObject lastSelection;
    bool canQuit = true;
    public bool quitSecurityOff;

    private void Awake()
    {
        //temp to remove unity's debug updater which crashes with new input
        GameObject go = GameObject.Find("[Debug Updater]");
        if (go != null) DestroyImmediate(go);

        lastSelection = EventSystem.current.firstSelectedGameObject;
        if (lastSelection.CompareTag("ButtonOne"))
        {
            lastSelection.GetComponentInChildren<TextMeshProUGUI>().color = highlightColor;
            oneDetails.SetActive(true);
        }
        else
            Debug.LogError("The first object should be ButtonOneController.");
        Invoke("QuitSecurity",.75f);
    }

    void Update()
    {
        if (canQuit && quitSecurityOff)
        {
            if (Gamepad.current != null && Keyboard.current != null)
            {
                if (Gamepad.current.buttonEast.ReadValue() > .8f || Keyboard.current.escapeKey.ReadValue() > .8f)
                    Application.Quit();
            }
            else if (Gamepad.current == null)
            {
                if (Keyboard.current.escapeKey.ReadValue() > .8f)
                    Application.Quit();
            }
            else
            {
                if (Gamepad.current.buttonEast.ReadValue() > .8f)
                    Application.Quit();
            }
        }
        if(EventSystem.current.currentSelectedGameObject != lastSelection)
        {
            switch (EventSystem.current.currentSelectedGameObject.tag)
            {
                case "ButtonOne":
                    EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().SetTrigger("Selected");
                    DJ.instance.PlaySound(DJ.SoundsKeyWord.Change);
                    lastSelection.GetComponentInChildren<TextMeshProUGUI>().color = normalColor;
                    lastSelection = EventSystem.current.currentSelectedGameObject;
                    lastSelection.GetComponentInChildren<TextMeshProUGUI>().color = highlightColor;
                    oneDetails.SetActive(true);
                    severalDetails.SetActive(false);
                    break;
                case "ButtonSeveral":
                    EventSystem.current.currentSelectedGameObject.GetComponent<Animator>().SetTrigger("Selected");
                    DJ.instance.PlaySound(DJ.SoundsKeyWord.Change);
                    lastSelection.GetComponentInChildren<TextMeshProUGUI>().color = normalColor;
                    lastSelection = EventSystem.current.currentSelectedGameObject;
                    lastSelection.GetComponentInChildren<TextMeshProUGUI>().color = highlightColor;
                    oneDetails.SetActive(false);
                    severalDetails.SetActive(true);
                    break;
                case "PlayersNumberSelection":
                    lastSelection = EventSystem.current.currentSelectedGameObject;
                  //  lastSelection.GetComponent<TextMeshProUGUI>().color = highlightColor;
                    oneDetails.SetActive(false);
                    severalDetails.SetActive(false);
                    break;
                default:
                    Debug.LogError("Please define a tag for this object : " + EventSystem.current.currentSelectedGameObject.name);
                    break;
            }
        }
    }

    void QuitSecurity()
    {
        quitSecurityOff = true;
    }

    public void CantQuit()
    {
        canQuit = false;
    }
}
