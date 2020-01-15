using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefeatScript : MonoBehaviour
{
    Animator winOutAnimator;
    public TextMeshProUGUI outPlayer;
    public TextMeshProUGUI winPlayer;
    public bool destroySecurity;

    private void Start()
    {
        winOutAnimator = GameObject.FindGameObjectWithTag("WinOut").GetComponent<Animator>();
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
                    winOutAnimator.SetTrigger("Win");
                    winPlayer.text = GameManager.instance.newPlayer;
                    winPlayer.color = GetPlayerColor(GameManager.instance.newPlayer);
                }
                else
                {
                    if (!GameManager.instance.dropping)
                    {
                        if (GameManager.instance.activePlayer == 0)
                        {
                            winOutAnimator.SetTrigger("Out");
                            outPlayer.text = OneControllerManager.instance.players[OneControllerManager.instance.players.Count - 1];
                            outPlayer.color = GetPlayerColor(OneControllerManager.instance.players[OneControllerManager.instance.players.Count - 1]);
                            OneControllerManager.instance.players.RemoveAt(OneControllerManager.instance.players.Count - 1);
                        }
                        else
                        {
                            winOutAnimator.SetTrigger("Out");
                            outPlayer.text = OneControllerManager.instance.players[GameManager.instance.activePlayer - 1];
                            outPlayer.color = GetPlayerColor(OneControllerManager.instance.players[GameManager.instance.activePlayer - 1]);
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
                        winOutAnimator.SetTrigger("Out");
                        outPlayer.text = OneControllerManager.instance.players[GameManager.instance.activePlayer];
                        outPlayer.color = GetPlayerColor(OneControllerManager.instance.players[GameManager.instance.activePlayer]);
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
                    winOutAnimator.SetTrigger("Win");
                    winPlayer.text = GameManager.instance.newPlayer;
                    winPlayer.color = GetPlayerColor(GameManager.instance.newPlayer);
                }
                else
                {
                    if (!GameManager.instance.dropping)
                    {
                        if (GameManager.instance.activePlayer == 0)
                        {
                            winOutAnimator.SetTrigger("Out");
                            outPlayer.text = PlayersManager.instance.players[PlayersManager.instance.players.Count - 1].ID;
                            outPlayer.color = GetPlayerColor(PlayersManager.instance.players[PlayersManager.instance.players.Count - 1].ID);
                            PlayersManager.instance.players.RemoveAt(PlayersManager.instance.players.Count - 1);
                        }
                        else
                        {
                            winOutAnimator.SetTrigger("Out");
                            outPlayer.text = PlayersManager.instance.players[GameManager.instance.activePlayer - 1].ID;
                            outPlayer.color = GetPlayerColor(PlayersManager.instance.players[GameManager.instance.activePlayer - 1].ID);
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
                        winOutAnimator.SetTrigger("Out");
                        outPlayer.text = PlayersManager.instance.players[GameManager.instance.activePlayer].ID;
                        outPlayer.color = GetPlayerColor(PlayersManager.instance.players[GameManager.instance.activePlayer].ID);
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

    Color GetPlayerColor(string player)
    {
        switch (player)
        {
            case "P1":
                return GameManager.instance.p1Color;
            case "P2":
                return GameManager.instance.p2Color;
            case "P3":
                return GameManager.instance.p3Color;
            case "P4":
                return GameManager.instance.p4Color;
            case "P5":
                return GameManager.instance.p5Color;
            case "P6":
                return GameManager.instance.p6Color;
            default:
                return Color.white;
        }
    }
}
