using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu_start : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("Text").GetComponent<Text>().text = "Highest Score: " + PlayerPrefs.GetInt("score");
	}
}
