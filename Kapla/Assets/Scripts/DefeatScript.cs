using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefeatScript : MonoBehaviour
{
    TextMeshProUGUI defeatText;

    private void Start()
    {
        defeatText = GameObject.FindGameObjectWithTag("DefeatText").GetComponent<TextMeshProUGUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Piece>())
        {
            GameManager.instance.defeat = true;
            defeatText.text = GameManager.instance.lastPlayer + " LOOSE";
        }
    }
}
