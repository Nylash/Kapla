using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayersNumberSelection : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] GameObject lessObject;
    [SerializeField] GameObject moreObject;
#pragma warning restore 0649

    TextMeshProUGUI textObject;
    bool updatingValue;
    public int currentPlayersNumber = 2;

    private void Start()
    {
        textObject = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (!OneControllerManager.instance.controlsPanel.activeSelf)
        {
            if (Gamepad.current != null && Keyboard.current != null)
            {
                if ((Gamepad.current.leftStick.ReadValue().x > .8f || Keyboard.current.dKey.ReadValue() > .8f || Keyboard.current.rightArrowKey.ReadValue() > .8f) && !updatingValue)
                {
                    IncreasePlayersNumber();
                }
                if ((Gamepad.current.leftStick.ReadValue().x < -.8f || Keyboard.current.aKey.ReadValue() > .8f || Keyboard.current.qKey.ReadValue() > .8f || Keyboard.current.leftArrowKey.ReadValue() > .8f) && !updatingValue)
                {
                    DecreasePlayersNumber();
                }
                if ((Gamepad.current.leftStick.ReadValue().x < .2f && Gamepad.current.leftStick.ReadValue().x > -.2f && Keyboard.current.dKey.ReadValue() < .2f && Keyboard.current.aKey.ReadValue() < .2f
                    && Keyboard.current.qKey.ReadValue() < .2f && Keyboard.current.rightArrowKey.ReadValue() < .2f && Keyboard.current.leftArrowKey.ReadValue() < .2f) && updatingValue)
                {
                    updatingValue = false;
                }
            }
            else if (Gamepad.current == null)
            {
                if ((Keyboard.current.dKey.ReadValue() > .8f || Keyboard.current.rightArrowKey.ReadValue() > .8f) && !updatingValue)
                {
                    IncreasePlayersNumber();
                }
                if ((Keyboard.current.aKey.ReadValue() > .8f || Keyboard.current.qKey.ReadValue() > .8f || Keyboard.current.leftArrowKey.ReadValue() > .8f) && !updatingValue)
                {
                    DecreasePlayersNumber();
                }
                if ((Keyboard.current.dKey.ReadValue() < .2f && Keyboard.current.aKey.ReadValue() < .2f && Keyboard.current.qKey.ReadValue() < .2f
                    && Keyboard.current.rightArrowKey.ReadValue() < .2f && Keyboard.current.leftArrowKey.ReadValue() < .2f) && updatingValue)
                {
                    updatingValue = false;
                }
            }
            else
            {
                if (Gamepad.current.leftStick.ReadValue().x > .8f && !updatingValue)
                {
                    IncreasePlayersNumber();
                }
                if (Gamepad.current.leftStick.ReadValue().x < -.8f && !updatingValue)
                {
                    DecreasePlayersNumber();
                }
                if ((Gamepad.current.leftStick.ReadValue().x < .2f && Gamepad.current.leftStick.ReadValue().x > -.2f) && updatingValue)
                {
                    updatingValue = false;
                }
            }
        }
    }

    void IncreasePlayersNumber()
    {
        moreObject.GetComponent<Animator>().SetTrigger("Selected");
        DJ.instance.PlaySound(DJ.SoundsKeyWord.Change);
        updatingValue = true;
        switch (currentPlayersNumber)
        {
            case 2:
                currentPlayersNumber = 3;
                lessObject.SetActive(true);
                break;
            case 3:
                currentPlayersNumber = 4;
                break;
            case 4:
                currentPlayersNumber = 5;
                break;
            case 5:
                currentPlayersNumber = 6;
                moreObject.SetActive(false);
                break;
            default:
                break;
        }
        textObject.text = currentPlayersNumber.ToString();
    }

    void DecreasePlayersNumber()
    {
        lessObject.GetComponent<Animator>().SetTrigger("Selected");
        DJ.instance.PlaySound(DJ.SoundsKeyWord.Change);
        updatingValue = true;
        switch (currentPlayersNumber)
        {
            case 3:
                currentPlayersNumber = 2;
                lessObject.SetActive(false);
                break;
            case 4:
                currentPlayersNumber = 3;
                break;
            case 5:
                currentPlayersNumber = 4;
                break;
            case 6:
                currentPlayersNumber = 5;
                moreObject.SetActive(true);
                break;
            default:
                break;
        }
        textObject.text = currentPlayersNumber.ToString();
    }
}
