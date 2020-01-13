using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefeatScript : MonoBehaviour
{
    Animator defeatAnimator;
    TextMeshProUGUI defeatText;
    public bool destroySecurity;

    private void Start()
    {
        defeatAnimator = GameObject.FindGameObjectWithTag("DefeatCanvas").GetComponent<Animator>();
        defeatText = GameObject.FindGameObjectWithTag("DefeatCanvas").GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piece"))
        {
            if (GameManager.instance.oneController)
            {
                if (OneControllerManager.instance.players.Count == 2)
                {
                    StartCoroutine(GameManager.instance.BigShake());
                    GameManager.instance.defeat = true;
                    defeatAnimator.SetTrigger("Defeat");
                    defeatText.text = GameManager.instance.newPlayer + " WIN !";
                }
                else
                {
                    if (!GameManager.instance.dropping)
                    {
                        if (GameManager.instance.activePlayer == 0)
                        {
                            defeatAnimator.SetTrigger("Out");
                            defeatText.text = OneControllerManager.instance.players[OneControllerManager.instance.players.Count - 1] + " is out !";
                            OneControllerManager.instance.players.RemoveAt(OneControllerManager.instance.players.Count - 1);
                        }
                        else
                        {
                            defeatAnimator.SetTrigger("Out");
                            defeatText.text = OneControllerManager.instance.players[GameManager.instance.activePlayer - 1] + " is out !";
                            OneControllerManager.instance.players.RemoveAt(GameManager.instance.activePlayer - 1);
                            GameManager.instance.activePlayer--;
                        }
                        if (collision.gameObject.GetComponent<TrainRigidbody>())
                        {
                            if (GameManager.instance.AllPieces.Contains(collision.gameObject.transform.parent.gameObject))
                                GameManager.instance.AllPieces.Remove(collision.gameObject.transform.parent.gameObject);
                            foreach (TrainRigidbody item in collision.gameObject.transform.parent.GetComponentsInChildren<TrainRigidbody>())
                            {
                                item.gameObject.tag = "Untagged";
                            }
                        }
                        else
                        {
                            if (GameManager.instance.AllPieces.Contains(collision.gameObject))
                                GameManager.instance.AllPieces.Remove(collision.gameObject);
                            collision.gameObject.tag = "Untagged";
                        }
                    }
                    else
                    {
                        defeatAnimator.SetTrigger("Out");
                        defeatText.text = OneControllerManager.instance.players[GameManager.instance.activePlayer] + " is out !";
                        OneControllerManager.instance.players.RemoveAt(GameManager.instance.activePlayer);
                        GameManager.instance.activePlayer--;
                        if (collision.gameObject.GetComponent<TrainRigidbody>())
                        {
                            if (GameManager.instance.AllPieces.Contains(collision.gameObject.transform.parent.gameObject))
                                GameManager.instance.AllPieces.Remove(collision.gameObject.transform.parent.gameObject);
                            foreach (TrainRigidbody item in collision.gameObject.transform.parent.GetComponentsInChildren<TrainRigidbody>())
                            {
                                item.gameObject.tag = "Untagged";
                            }
                            if(collision.gameObject.layer == LayerMask.NameToLayer("ToPlace"))
                                collision.gameObject.transform.parent.GetComponent<Piece>().PieceFallen();
                        }
                        else
                        {
                            if (GameManager.instance.AllPieces.Contains(collision.gameObject))
                                GameManager.instance.AllPieces.Remove(collision.gameObject);
                            collision.gameObject.tag = "Untagged";
                            if(collision.gameObject.layer == LayerMask.NameToLayer("ToPlace"))
                                collision.gameObject.GetComponent<Piece>().PieceFallen();
                        }

                    }
                }
            }
            else
            {
                if (PlayersManager.instance.players.Count == 2)
                {
                    StartCoroutine(GameManager.instance.BigShake());
                    GameManager.instance.defeat = true;
                    defeatAnimator.SetTrigger("Defeat");
                    defeatText.text = GameManager.instance.newPlayer + " WIN !";
                }
                else
                {
                    if (!GameManager.instance.dropping)
                    {
                        if (GameManager.instance.activePlayer == 0)
                        {
                            defeatAnimator.SetTrigger("Out");
                            defeatText.text = PlayersManager.instance.players[PlayersManager.instance.players.Count - 1].ID + " is out !";
                            PlayersManager.instance.players.RemoveAt(PlayersManager.instance.players.Count - 1);
                        }
                        else
                        {
                            defeatAnimator.SetTrigger("Out");
                            defeatText.text = PlayersManager.instance.players[GameManager.instance.activePlayer - 1].ID + " is out !";
                            PlayersManager.instance.players.RemoveAt(GameManager.instance.activePlayer - 1);
                            GameManager.instance.activePlayer--;
                        }
                        if (collision.gameObject.GetComponent<TrainRigidbody>())
                        {
                            if (GameManager.instance.AllPieces.Contains(collision.gameObject.transform.parent.gameObject))
                                GameManager.instance.AllPieces.Remove(collision.gameObject.transform.parent.gameObject);
                            foreach (TrainRigidbody item in collision.gameObject.transform.parent.GetComponentsInChildren<TrainRigidbody>())
                            {
                                item.gameObject.tag = "Untagged";
                            }
                        }
                        else
                        {
                            if (GameManager.instance.AllPieces.Contains(collision.gameObject))
                                GameManager.instance.AllPieces.Remove(collision.gameObject);
                            collision.gameObject.tag = "Untagged";
                        }
                    }
                    else
                    {
                        defeatAnimator.SetTrigger("Out");
                        defeatText.text = PlayersManager.instance.players[GameManager.instance.activePlayer].ID + " is out !";
                        PlayersManager.instance.players.RemoveAt(GameManager.instance.activePlayer);
                        GameManager.instance.activePlayer--;
                        if (collision.gameObject.GetComponent<TrainRigidbody>())
                        {
                            if (GameManager.instance.AllPieces.Contains(collision.gameObject.transform.parent.gameObject))
                                GameManager.instance.AllPieces.Remove(collision.gameObject.transform.parent.gameObject);
                            foreach (TrainRigidbody item in collision.gameObject.transform.parent.GetComponentsInChildren<TrainRigidbody>())
                            {
                                item.gameObject.tag = "Untagged";
                            }
                            if(collision.gameObject.layer == LayerMask.NameToLayer("ToPlace"))
                                collision.gameObject.transform.parent.GetComponent<Piece>().PieceFallen();
                        }
                        else
                        {
                            if (GameManager.instance.AllPieces.Contains(collision.gameObject))
                                GameManager.instance.AllPieces.Remove(collision.gameObject);
                            collision.gameObject.tag = "Untagged";
                            if(collision.gameObject.layer == LayerMask.NameToLayer("ToPlace"))
                                collision.gameObject.GetComponent<Piece>().PieceFallen();
                        }
                    }
                }
            }
        }
    }
}
