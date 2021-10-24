using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScene : MonoBehaviour
{
    public void GoToPlayground()
    {
        PlayerPrefs.DeleteKey("CoinCount");
        SceneManager.LoadScene("Playground");
    }

    public void ContinuePlay()
    {
        if(PlayerPrefs.HasKey("PrevScene"))
        {
            string prevSceneName = PlayerPrefs.GetString("PrevScene");
            SceneManager.LoadScene(prevSceneName);
        }
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
