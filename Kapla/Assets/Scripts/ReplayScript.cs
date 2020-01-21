using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ReplayScript : MonoBehaviour
{
    GameObject lastSelected;

    // Update is called once per frame
    void Update()
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
}
