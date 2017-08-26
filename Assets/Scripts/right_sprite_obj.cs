using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class right_sprite_obj : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        transform.localScale = Vector3.one * Screen.width / 32f;
        Vector3 base_pos = new Vector3((float)(start.rightbound), (float)2, (float)(transform.position.z));
        transform.position = base_pos;


    }

    // Update is called once per frame
    void Update()
    {
        if (!start.end && !start.pause && start.beta_testing)
        {
            transform.Rotate(0, 90 * Time.deltaTime, 0);
            //transform.position += start.sprite_movement;
            transform.Translate(0, (float)-start.speed * 2 * Time.deltaTime, 0);

            if (transform.position.y < -1)
            {
                var base_pos = new Vector3((float)(start.rightbound), (float)2, (float)(transform.position.z));
            
                transform.position = base_pos;

                var rand_pos = new Vector3(0, (float)Random.Range(0, (float)2));
                transform.position += rand_pos;
            }
        }else if(!start.beta_testing){
            transform.position = new Vector3((float)(start.rightbound), (float)(2+ Random.Range(0,2)), (float)(transform.position.z));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        start.end = true;
    }
}
