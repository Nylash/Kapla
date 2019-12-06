using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefeatScript : MonoBehaviour
{
    Animator defeatAnimator;
    TextMeshProUGUI defeatText;

    private void Start()
    {
        defeatAnimator = GameObject.FindGameObjectWithTag("DefeatCanvas").GetComponent<Animator>();
        defeatText = GameObject.FindGameObjectWithTag("DefeatCanvas").GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Piece>())
        {
            StartCoroutine(GameManager.instance.BigShake());
            GameManager.instance.defeat = true;
            defeatAnimator.SetTrigger("Launch");
            defeatText.text = GameManager.instance.lastPlayer.ID + " LOOSE !";
        }
    }
}
