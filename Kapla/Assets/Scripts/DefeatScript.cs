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
        if (collision.gameObject.GetComponent<Piece>() || collision.gameObject.GetComponentInParent<Piece>())
        {
            if (GameManager.instance.oneController)
            {
                if(OneControllerManager.instance.players.Count == 2)
                {
                    StartCoroutine(GameManager.instance.BigShake());
                    GameManager.instance.defeat = true;
                    defeatAnimator.SetTrigger("Launch");
                    defeatText.text = GameManager.instance.newPlayer + " WIN !";
                }
            }
            else
            {
                if(PlayersManager.instance.players.Count == 2)
                {
                    StartCoroutine(GameManager.instance.BigShake());
                    GameManager.instance.defeat = true;
                    defeatAnimator.SetTrigger("Launch");
                    defeatText.text = GameManager.instance.newPlayer + " WIN !";
                }
            }
            
        }
    }
}
