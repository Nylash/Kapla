﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

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

    private void Awake()
    {
        lastSelection = EventSystem.current.firstSelectedGameObject;
        if (lastSelection.CompareTag("ButtonOne"))
        {
            lastSelection.GetComponentInChildren<TextMeshProUGUI>().color = highlightColor;
            oneDetails.SetActive(true);
        }
        else
            Debug.LogError("The first object should be ButtonOneController.");
            
    }

    void Update()
    {
        if(EventSystem.current.currentSelectedGameObject != lastSelection)
        {
            switch (EventSystem.current.currentSelectedGameObject.tag)
            {
                case "ButtonOne":
                    lastSelection.GetComponentInChildren<TextMeshProUGUI>().color = normalColor;
                    lastSelection = EventSystem.current.currentSelectedGameObject;
                    lastSelection.GetComponentInChildren<TextMeshProUGUI>().color = highlightColor;
                    oneDetails.SetActive(true);
                    severalDetails.SetActive(false);
                    break;
                case "ButtonSeveral":
                    lastSelection.GetComponentInChildren<TextMeshProUGUI>().color = normalColor;
                    lastSelection = EventSystem.current.currentSelectedGameObject;
                    lastSelection.GetComponentInChildren<TextMeshProUGUI>().color = highlightColor;
                    oneDetails.SetActive(false);
                    severalDetails.SetActive(true);
                    break;
                case "PlayersNumberSelection":
                    lastSelection = EventSystem.current.currentSelectedGameObject;
                    lastSelection.GetComponent<TextMeshProUGUI>().color = highlightColor;
                    oneDetails.SetActive(false);
                    severalDetails.SetActive(false);
                    break;
                default:
                    Debug.LogError("Please define a tag for this object : " + EventSystem.current.currentSelectedGameObject.name);
                    break;
            }
        }
    }
}