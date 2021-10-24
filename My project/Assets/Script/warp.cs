using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class warp : MonoBehaviour
{
    public string sceneName;
    public AudioSource warpSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("LoadNextScene", 0.7f);
            //บันทึกScene
            PlayerPrefs.SetString("PrevScene", sceneName);
            //บันทึกเหรียญ
            var player = other.gameObject.GetComponent<PlayerRigibady>();
            
            PlayerPrefs.SetInt("CoinCount", player.coinCount);
            warpSound?.Play();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

