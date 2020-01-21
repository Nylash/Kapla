using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class DefeatScript : MonoBehaviour
{
    Animator winOutAnimator;
    public TextMeshProUGUI outPlayer;
    public TextMeshProUGUI winPlayer;
    public bool destroySecurity;
    public bool inRecovery;

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
                if (OneControllerManager.instance.players.Count == 2 && !inRecovery)
                {
                    StartCoroutine(GameManager.instance.BigShake());
                    GameManager.instance.defeat = true;
                    winOutAnimator.SetTrigger("Win");
                    winPlayer.text = GameManager.instance.newPlayer;
                    winPlayer.color = GameManager.instance.GetPlayerColor(GameManager.instance.newPlayer);
                    GameManager.instance.replayButtons.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameManager.instance.replayButtons.transform.GetChild(0).gameObject);
                    OneControllerManager.instance.canPlay = false;
                }
                else
                {
                    if (!GameManager.instance.dropping)
                    {
                        if (!inRecovery)
                        {
                            inRecovery = true;
                            Invoke("EndRecovery", GameManager.instance.invicibleTime);
                            if (GameManager.instance.activePlayer == 0)
                            {
                                winOutAnimator.SetTrigger("Out");
                                outPlayer.text = OneControllerManager.instance.players[OneControllerManager.instance.players.Count - 1];
                                outPlayer.color = GameManager.instance.GetPlayerColor(OneControllerManager.instance.players[OneControllerManager.instance.players.Count - 1]);
                                OneControllerManager.instance.players.RemoveAt(OneControllerManager.instance.players.Count - 1);
                            }
                            else
                            {
                                winOutAnimator.SetTrigger("Out");
                                outPlayer.text = OneControllerManager.instance.players[GameManager.instance.activePlayer - 1];
                                outPlayer.color = GameManager.instance.GetPlayerColor(OneControllerManager.instance.players[GameManager.instance.activePlayer - 1]);
                                OneControllerManager.instance.players.RemoveAt(GameManager.instance.activePlayer - 1);
                                GameManager.instance.activePlayer--;
                            }
                        }
                    }
                    else
                    {
                        winOutAnimator.SetTrigger("Out");
                        outPlayer.text = OneControllerManager.instance.players[GameManager.instance.activePlayer];
                        outPlayer.color = GameManager.instance.GetPlayerColor(OneControllerManager.instance.players[GameManager.instance.activePlayer]);
                        OneControllerManager.instance.players.RemoveAt(GameManager.instance.activePlayer);
                        GameManager.instance.activePlayer--;
                    }
                }
            }
            else
            {
                if (PlayersManager.instance.players.Count == 2 && !inRecovery)
                {
                    StartCoroutine(GameManager.instance.BigShake());
                    GameManager.instance.defeat = true;
                    winOutAnimator.SetTrigger("Win");
                    winPlayer.text = GameManager.instance.newPlayer;
                    winPlayer.color = GameManager.instance.GetPlayerColor(GameManager.instance.newPlayer);
                    GameManager.instance.replayButtons.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameManager.instance.replayButtons.transform.GetChild(0).gameObject);
                    foreach (PlayerInputs item in PlayersManager.instance.players)
                        item.state = PlayerInputs.PlayerState.NotHisTurn;
                }
                else
                {
                    if (!GameManager.instance.dropping)
                    {
                        if (!inRecovery)
                        {
                            inRecovery = true;
                            Invoke("EndRecovery", GameManager.instance.invicibleTime);
                            if (GameManager.instance.activePlayer == 0)
                            {
                                winOutAnimator.SetTrigger("Out");
                                outPlayer.text = PlayersManager.instance.players[PlayersManager.instance.players.Count - 1].ID;
                                outPlayer.color = GameManager.instance.GetPlayerColor(PlayersManager.instance.players[PlayersManager.instance.players.Count - 1].ID);
                                PlayersManager.instance.players.RemoveAt(PlayersManager.instance.players.Count - 1);
                            }
                            else
                            {
                                winOutAnimator.SetTrigger("Out");
                                outPlayer.text = PlayersManager.instance.players[GameManager.instance.activePlayer - 1].ID;
                                outPlayer.color = GameManager.instance.GetPlayerColor(PlayersManager.instance.players[GameManager.instance.activePlayer - 1].ID);
                                PlayersManager.instance.players.RemoveAt(GameManager.instance.activePlayer - 1);
                                GameManager.instance.activePlayer--;
                            }
                        }
                    }
                    else
                    {
                        winOutAnimator.SetTrigger("Out");
                        outPlayer.text = PlayersManager.instance.players[GameManager.instance.activePlayer].ID;
                        outPlayer.color = GameManager.instance.GetPlayerColor(PlayersManager.instance.players[GameManager.instance.activePlayer].ID);
                        PlayersManager.instance.players.RemoveAt(GameManager.instance.activePlayer);
                        GameManager.instance.activePlayer--;
                    }
                }
            }
            if (collision.gameObject.GetComponent<TrainRigidbody>())
            {
                if (GameManager.instance.AllPieces.Contains(collision.gameObject.transform.parent.gameObject))
                    GameManager.instance.AllPieces.Remove(collision.gameObject.transform.parent.gameObject);
                foreach (TrainRigidbody item in collision.gameObject.transform.parent.GetComponentsInChildren<TrainRigidbody>())
                {
                    item.gameObject.tag = "Untagged";
                }
                if (collision.gameObject.layer == LayerMask.NameToLayer("ToPlace"))
                    collision.gameObject.transform.parent.GetComponent<Piece>().PieceFallen();
                else
                    collision.gameObject.transform.parent.GetComponent<Piece>().Explosion();
            }
            else
            {
                if (GameManager.instance.AllPieces.Contains(collision.gameObject))
                    GameManager.instance.AllPieces.Remove(collision.gameObject);
                collision.gameObject.tag = "Untagged";
                if (collision.gameObject.layer == LayerMask.NameToLayer("ToPlace"))
                    collision.gameObject.GetComponent<Piece>().PieceFallen();
                else
                    collision.gameObject.GetComponent<Piece>().Explosion();
            }
        }
    }

    void EndRecovery()
    {
        inRecovery = false;
    }
}
