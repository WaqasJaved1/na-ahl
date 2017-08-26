using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class play_btn_sc : MonoBehaviour {

	// Use this for initialization
    public void play(string level) {

        Debug.Log(PlayerPrefs.GetInt("first_time"));
        if (PlayerPrefs.GetInt("first_time") == 0)
        {
            PlayerPrefs.SetInt("first_time", 1);
            SceneManager.LoadScene("guide");
        }else
        {
            SceneManager.LoadScene(level);
        }


        
    }
}
