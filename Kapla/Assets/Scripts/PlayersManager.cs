using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayersManager : MonoBehaviour
{
#pragma warning disable 0649
    [Header("LOBBY OBJECTS")]
    [SerializeField] GameObject loadObject;
    [SerializeField] GameObject P1;
    [SerializeField] GameObject P2;
    [SerializeField] GameObject P3;
    [SerializeField] GameObject P4;
    [Header("INFO")]
#pragma warning restore 0649
    public static PlayersManager instance = null;
    public List<PlayerInputs> players = new List<PlayerInputs>();
    public bool inLobby = true;

    List<PlayerInputs> stockedPlayers = new List<PlayerInputs>();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        //temp to remove unity's debug updater which crashes with new input
        GameObject go = GameObject.Find("[Debug Updater]");
        if (go != null) DestroyImmediate(go);
    }

    private void OnEnable()
    {
        StartCoroutine(ActivateJoining());
    }

    IEnumerator ActivateJoining()
    {
        yield return new WaitForSeconds(.2f);
        GetComponent<PlayerInputManager>().EnableJoining();
    }

    void OnPlayerJoined(PlayerInput player)
    {
        players.Add(player.GetComponent<PlayerInputs>());
        players[players.Count - 1].ID = "P" + players.Count;
        switch (players.Count)
        {
            case 1:
                P1.SetActive(true);
                if (players[0].gameObject.GetComponent<PlayerInput>().currentControlScheme == "Gamepad")
                    P1.transform.GetChild(2).gameObject.SetActive(true);
                else
                    P1.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 2:
                P2.SetActive(true);
                if (players[1].gameObject.GetComponent<PlayerInput>().currentControlScheme == "Gamepad")
                    P2.transform.GetChild(2).gameObject.SetActive(true);
                else
                    P2.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 3:
                P3.SetActive(true);
                if (players[2].gameObject.GetComponent<PlayerInput>().currentControlScheme == "Gamepad")
                    P3.transform.GetChild(2).gameObject.SetActive(true);
                else
                    P3.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 4:
                P4.SetActive(true);
                if (players[3].gameObject.GetComponent<PlayerInput>().currentControlScheme == "Gamepad")
                    P4.transform.GetChild(2).gameObject.SetActive(true);
                else
                    P4.transform.GetChild(3).gameObject.SetActive(true);
                break;
            default:
                break;
        }
        if (players.Count == 2)
            loadObject.SetActive(true);
    }

    public void Restart()
    {
        players.Clear();
        players.AddRange(stockedPlayers);
        GameManager.instance.Restart();
    }

    public void LoadGame()
    {
        DJ.instance.PlaySound(DJ.SoundsKeyWord.Validation);
        GetComponent<PlayerInputManager>().DisableJoining();
        DontDestroyOnLoad(gameObject);
        foreach (PlayerInputs item in players)
        {
            DontDestroyOnLoad(item);
        }
        inLobby = false;
        stockedPlayers.AddRange(players);
        SceneManager.LoadScene("Room");
        DJ.instance.PlayMusic(DJ.MusicKeyWork.Game);
    }
}
