using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayersManager : MonoBehaviour
{
    public static PlayersManager instance = null;
    public List<PlayerInputs> players = new List<PlayerInputs>();
    public bool inLobby = true;

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

        DontDestroyOnLoad(gameObject);
    }

    void OnPlayerJoined(PlayerInput player)
    {
        players.Add(player.GetComponent<PlayerInputs>());
        players[players.Count - 1].ID = "P" + players.Count;
        if(inLobby)
            GameObject.Find("Tmp").GetComponent<Text>().text += players[players.Count - 1].ID + " ";
    }

    public void LoadGame()
    {
        GetComponent<PlayerInputManager>().DisableJoining();
        inLobby = false;
        SceneManager.LoadScene("Ben");
    }

    public void DebugMode()
    {
        inLobby = false;
        GetComponent<PlayerInputManager>().JoinPlayer();
        GetComponent<PlayerInputManager>().DisableJoining();
    }
}
