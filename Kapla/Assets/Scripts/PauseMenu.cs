using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject controlsPanel;
    GameObject lastSelected;
    GameObject stockEventSystem;
    bool inControls;

    void Update()
    {
        if (!inControls)
        {
            if (EventSystem.current.currentSelectedGameObject != lastSelected)
            {
                if (lastSelected)
                {
                    lastSelected.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
                    if (lastSelected.GetComponent<Image>().color != Color.white)
                        lastSelected.GetComponent<Image>().color = Color.white;
                }
                else
                    transform.GetChild(0).GetComponent<Image>().color = Color.black;
                lastSelected = EventSystem.current.currentSelectedGameObject;
                DJ.instance.PlaySound(DJ.SoundsKeyWord.Change);
                lastSelected.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
                lastSelected.GetComponent<Animator>().SetTrigger("Selected");
            }
        }
        else
        {
            if (Gamepad.current != null && Keyboard.current != null)
            {
                if (Gamepad.current.buttonEast.ReadValue() > .8f || Keyboard.current.escapeKey.ReadValue() > .8f)
                {
                    controlsPanel.SetActive(false);
                    stockEventSystem.SetActive(true);
                    inControls = false;
                }
            }
            else if (Gamepad.current == null)
            {
                if (Keyboard.current.escapeKey.ReadValue() > .8f)
                {
                    controlsPanel.SetActive(false);
                    stockEventSystem.SetActive(true);
                    inControls = false;
                }
            }
            else
            {
                if (Gamepad.current.buttonEast.ReadValue() > .8f)
                {
                    controlsPanel.SetActive(false);
                    stockEventSystem.SetActive(true);
                    inControls = false;
                }
            }
        }
    }

    public void ResetFont()
    {
        lastSelected = null;
        foreach (TextMeshProUGUI item in GetComponentsInChildren<TextMeshProUGUI>())
        {
            item.color = Color.black;
        }
    }

    public void UnselectControlsButton()
    {
        stockEventSystem = EventSystem.current.gameObject;
        EventSystem.current.gameObject.SetActive(false);
        inControls = true;
    }
}
