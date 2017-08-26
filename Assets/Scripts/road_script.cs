using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road_script : MonoBehaviour {
    Vector3 base_pos;
	// Use this for initialization
	void Start () {
        transform.localScale = Vector3.one * Screen.width / 6f;
        base_pos = new Vector3(0, (float)5.85, (float)(transform.position.z));

	}
	
	// Update is called once per frame
	void Update () {
        if ((!start.end && !start.pause))
        {


            transform.position += start.sprite_movement;

            if (transform.position.y < -4)
            {
                transform.position = base_pos;
            }
        }
	}
}
