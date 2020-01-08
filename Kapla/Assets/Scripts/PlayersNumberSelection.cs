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
        if(Gamepad.current != null && Keyboard.current != null)
        {
            if ((Gamepad.current.leftStick.ReadValue().x > .8f || Keyboard.current.dKey.ReadValue() > .8f) && !updatingValue)
            {
                IncreasePlayersNumber();
            }
            if ((Gamepad.current.leftStick.ReadValue().x < -.8f || Keyboard.current.aKey.ReadValue() > .8f || Keyboard.current.qKey.ReadValue() > .8f) && !updatingValue)
            {
                DecreasePlayersNumber();
            }
            if (((Gamepad.current.leftStick.ReadValue().x < .2f && Gamepad.current.leftStick.ReadValue().x > -.2f) && (Keyboard.current.dKey.ReadValue() < .2f && (Keyboard.current.aKey.ReadValue() < .2f && Keyboard.current.qKey.ReadValue() < .2f))) && updatingValue)
            {
                updatingValue = false;
            }
        }
        else if(Gamepad.current == null)
        {
            if (Keyboard.current.dKey.ReadValue() > .8f && !updatingValue)
            {
                IncreasePlayersNumber();
            }
            if ((Keyboard.current.aKey.ReadValue() > .8f || Keyboard.current.qKey.ReadValue() > .8f) && !updatingValue)
            {
                DecreasePlayersNumber();
            }
            if ((Keyboard.current.dKey.ReadValue() < .2f && (Keyboard.current.aKey.ReadValue() < .2f && Keyboard.current.qKey.ReadValue() < .2f)) && updatingValue)
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

    void IncreasePlayersNumber()
    {
        updatingValue = true;
        switch (currentPlayersNumber)
        {
            case 2:
                currentPlayersNumber = 3;
                lessObject.SetActive(true);
                break;
            case 3:
                currentPlayersNumber = 4;
                moreObject.SetActive(false);
                break;
            default:
                break;
        }
        textObject.text = currentPlayersNumber.ToString();
    }

    void DecreasePlayersNumber()
    {
        updatingValue = true;
        switch (currentPlayersNumber)
        {
            case 3:
                currentPlayersNumber = 2;
                lessObject.SetActive(false);
                break;
            case 4:
                currentPlayersNumber = 3;
                moreObject.SetActive(true);
                break;
            default:
                break;
        }
        textObject.text = currentPlayersNumber.ToString();
    }
}
