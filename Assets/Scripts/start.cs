using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour {
    double score;
    public static double speed;
    int level;
    public static bool pause;
    public static bool end;

    public static double leftbound;
    public static  double rightbound;
    bool movement_left;
    bool movement;
    bool magicstop;
    float magicpower;
    int highscore;
    public static bool beta_testing = false;
    public static Vector3 sprite_movement;

	// Use this for initialization
	void Start () {
        beta_testing = false;
        highscore = PlayerPrefs.GetInt("Score");
        score = 0.0;
        speed = 0.2;
        level = 1;
        pause = false;
        end = false;
        magicpower = 100;
        magicstop = false;
        movement = false;
        movement_left = false;

        var left_wall = GameObject.Find("left_wall").GetComponent<Renderer>().transform;
        var right_wall = GameObject.Find("right_wall").GetComponent<Renderer>().transform;

        left_wall.position = new Vector3((float)-0.7, left_wall.position.y, left_wall.position.z);
        right_wall.position = new Vector3((float)0.7, right_wall.position.y, right_wall.position.z);

        var object_obj = GameObject.Find("ob_main").GetComponent<Renderer>().transform;

        object_obj.transform.localScale = Vector3.one * Screen.width / 32f;

        GameObject.Find("level_txt").GetComponent<Text>().text = "Level: " + level;
        leftbound = left_wall.position.x + object_obj.lossyScale.x;
        rightbound = right_wall.position.x - object_obj.lossyScale.x;


        var t = new Vector3((float)rightbound, (float)0, (float)(GameObject.Find("Sprite_obj_ob").GetComponent<Renderer>().transform.position.z));
        GameObject.Find("Slider1").GetComponent<Slider>().value = magicpower/100;

        GameObject.Find("ob_main").GetComponent<Renderer>().transform.position = t;
        
        //GameObject.Find("Slider").GetComponent<Slider>().transform.SetPositionAndRotation(new Vector3((float)(GameObject.Find("right_wall").GetComponent<Renderer>().transform.position.x - 0.11), (float)-0.383, 0), quaternion);
        //GameObject.Find("Slider").GetComponent<Slider>().transform.localScale.Set((float)0.1, (float)0.1, (float)0.1);

        GameObject.Find("stage_name").GetComponent<Text>().text = "Stage: " + changeStage();
        sprite_movement = new Vector3(0, (float)(start.speed * -0.05), 0);

    }

    string changeStage()
    {
        string stageName = "Panama";

        if (level == 1)
        {
            stageName =  "Panama";
        }
        else if (level == 2)
        {
            stageName =  "Dharna";
        }
        else if (level == 3)
        {
            stageName = "JIT";
        }
        else if(level == 4)
        {
            stageName = "Na-Ahl";
        }else if(level >4){
            stageName = "Naya Pakistan";
        }

        GameObject.Find("stageAnimation").GetComponent<newsline_script>().start_motion(stageName);

        return stageName;
    }
	
	// Update is called once per frame
    void Update()
    {

        if (!pause && !end)
        {
            beta_testing = true;

            var test = new Vector3((float)(speed * 0.1), 0, 0);
            var test2 = new Vector3((float)(speed * 0.1 * 0.5), 0, 0);

            score += (float)level/5.0 * 0.1;
            magicpower = GameObject.Find("Slider1").GetComponent<Slider>().value * 100;

            GameObject.Find("score_txt").GetComponent<Text>().text = "Score: " + (int)score;

            var object_obj = GameObject.Find("ob_main").GetComponent<Renderer>().transform;

            Vector3 position = new Vector3((float)(speed * 0.1), 0, 0);


            if (score > level * 50)
            {
                if(level < 8){
                    speed += 0.1;

                    GameObject.Find("stage_name").GetComponent<Text>().text = "Stage: " + changeStage();

                }

                level++;
                GameObject.Find("level_txt").GetComponent<Text>().text = "Level: " + level;
                sprite_movement.Set(0, (float)(start.speed * -0.05), 0);




            }

            if (movement_left && movement && !magicstop)
            {
                if (object_obj.position.x > leftbound)
                {
                    object_obj.transform.position -= position;

                }
                else
                {
                    var t = new Vector3((float)leftbound, (float)0, (float)(GameObject.Find("Sprite_obj_ob").GetComponent<Renderer>().transform.position.z));
                    object_obj.transform.position = t;

                    movement = false;
                    movement_left = false;
                }
            }
            else if (!movement_left && movement && !magicstop)
            {
                if (object_obj.position.x < rightbound)
                {
                    object_obj.transform.position += position;

                }
                else
                {
                    var t = new Vector3((float)rightbound, (float)0, (float)(GameObject.Find("Sprite_obj_ob").GetComponent<Renderer>().transform.position.z));
                    object_obj.transform.position = t;

                    movement = false;
                    movement_left = true;
                }
            }


            //if()

            magicstop = false;

            if (Input.touchCount > 0)
            {


                if ((!movement && Input.GetTouch(0).position.x < Screen.width / 2))
                {
                    movement = true;
                }
                else if ((Input.GetTouch(0).position.x >= Screen.width / 2 && magicpower > 0))
                {
                    magicstop = true;

                    magicpower -= (float)(speed * 10);
                }
            }
            else if (magicpower < 100)
            {
                magicpower += (float)(speed);
            }

            GameObject.Find("Slider1").GetComponent<Slider>().value = magicpower / 100;
        }
        else if (end) {
            if (score > highscore)
            {
                PlayerPrefs.SetInt("score", (int)score);
            }
            GameObject.Find("Panel").transform.position = new Vector3(highscorepanel.x, highscorepanel.y, highscorepanel.z);

            GameObject.Find("sc").GetComponent<Text>().text = "Your Score: " + (int)score;
            GameObject.Find("highest_sc").GetComponent<Text>().text = "Highest Score: " + (int)highscore;
            enabled = false;
        }

    }

}
