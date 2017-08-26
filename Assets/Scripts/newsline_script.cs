using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newsline_script : MonoBehaviour {

    float start;
    float end;
    float mid;
    string stage;

    public float targetTime;
    // Use this for initialization
    void Start()
    {
        start = -4;
        end = 4;
        mid = 0;
        stage = "start";
        enabled = false;

        targetTime = 1.0f;
    }


    public void start_motion(string name) {
        transform.position = new Vector3(start, 0, transform.position.z);
        GameObject.Find("newsline").GetComponent<Text>().text = name;
        targetTime = 1.0f;

        stage = "left";
        enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (stage == "left")
        {
            transform.Translate((float)1 * Time.deltaTime, 0, 0);
            if(transform.position.x > mid){
                stage = "mid";
            }
        }else if(stage == "mid"){
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                stage = "right";
            }
        }
        else if (stage == "right")
        {
            transform.Translate((float)1 * Time.deltaTime, 0, 0);
            if (transform.position.x > end)
            {
                stage = "end";
                enabled = false;
            }
        }
    }
}
