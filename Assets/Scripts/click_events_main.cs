using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class click_events_main : MonoBehaviour {

    public Image stop;
    public Image play;


    public void back() {
        SceneManager.LoadScene("menu");
    }

    public void pause()
    {
  
        if(start.pause){

            start.pause = false;
            GameObject.Find("pause").GetComponent<Image>().sprite = Resources.Load<Sprite>("stop");
            return;
        }
        GameObject.Find("pause").GetComponent<Image>().sprite = Resources.Load<Sprite>("play");





        start.pause = true;
        //GameObject.Find("pause").
    }
}
