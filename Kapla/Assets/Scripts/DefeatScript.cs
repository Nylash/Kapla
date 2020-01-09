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
                else
                {
                    if (!GameManager.instance.freezeElim)
                    {
                        if (GameManager.instance.activePlayer == 0)
                        {
                            print(OneControllerManager.instance.players[OneControllerManager.instance.players.Count - 1] + " was removed");
                            OneControllerManager.instance.players.RemoveAt(OneControllerManager.instance.players.Count - 1);
                        }
                        else
                        {
                            print(OneControllerManager.instance.players[GameManager.instance.activePlayer - 1] + " was removed");
                            OneControllerManager.instance.players.RemoveAt(GameManager.instance.activePlayer - 1);
                            GameManager.instance.activePlayer--;
                        }
                    }
                    else
                    {
                        print("FREEEEEEEEEEEEZE");
                    }
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
