using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    private void Start()
    {
        //temp to remove unity's debug updater which crashes with new input
        GameObject go = GameObject.Find("[Debug Updater]");
        if (go != null) DestroyImmediate(go);
    }

        void LoadLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
