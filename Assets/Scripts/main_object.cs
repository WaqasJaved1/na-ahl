using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_object : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position.Set(transform.position.x, transform.position.y, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (!start.end && !start.pause)
        {
            transform.Rotate(0, 0, 360 * Time.deltaTime);
        }
        //transform.Rotate(0, 0, 3);
        
    }
}
