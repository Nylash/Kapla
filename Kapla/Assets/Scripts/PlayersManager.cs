using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayersManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] GameObject loadObject;
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
        GameObject.Find("Tmp").GetComponent<Text>().text += players[players.Count - 1].ID + " ";
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
