using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class highscorepanel : MonoBehaviour {
    public static float x;
    public static float y;
    public static float z;
	// Use this for initialization
	void Start () {
        var width = Screen.width;
        x = 0;
        y = (float)0.34;
        z = transform.position.z;

        transform.position = new Vector3((float)200,0,0);
        enabled = false;
    }
	


	public void End () {
        transform.position = new Vector3(x,y,z);
	}
}
