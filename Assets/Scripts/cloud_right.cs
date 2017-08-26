using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_right : MonoBehaviour
{
    Vector3 base_pos;
    float speed;
    // Use this for initialization
    void Start()
    {
        base_pos = new Vector3(transform.position.x, (float)2, (float)(transform.position.z));
        speed = (float)Random.Range((float)0.0004, (float)0.009);
        transform.localScale = Vector3.one * Screen.width / (Random.Range(0, (float)4) + 16f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((float)(start.rightbound + 4 * transform.lossyScale.x), transform.position.y, transform.position.z);

        transform.Translate(0, (float)-speed * 30 * Time.deltaTime, 0);

        if (transform.position.y < -1)
        {
            transform.position = base_pos;

            var rand_pos = new Vector3(0, (float)Random.Range(0, (float)1));
            transform.position += rand_pos;
            speed = (float)Random.Range((float)0.0004, (float)0.0008);
            transform.localScale = Vector3.one * Screen.width / (Random.Range(0, (float)4) + 16f);
        }
    }
}
