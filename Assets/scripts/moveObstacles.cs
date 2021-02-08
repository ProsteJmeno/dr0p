using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObstacles : MonoBehaviour
{

    GameObject[] obstacles;
    public float speedMultiplier;
    public float speedIncreaseDelay;
    public float speedIncreaseDifference;
    float lastSpeedTime;


    float actualTime;

    void Start()
    {
        lastSpeedTime = Time.time;
        actualTime = Time.time;

        obstacles = GameObject.FindGameObjectsWithTag("obstacle");
    }

    void Update()
    {
        actualTime = Time.time;

        obstacles = GameObject.FindGameObjectsWithTag("obstacle");

        

        if (actualTime >= lastSpeedTime + speedIncreaseDelay)
        {
            speedMultiplier += speedIncreaseDifference;
            lastSpeedTime = Time.time;
        }
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().enabled == true)
        {
            foreach (GameObject obj in obstacles)
            {
                if (obj != null)
                {
                    obj.transform.position = new Vector3(0, obj.transform.position.y - (1 * speedMultiplier), 0);
                    //obj.transform.Translate(new Vector3(0, obj.transform.position.y - (1 * speedMultiplier), 0));
                }
            }
        }
    }
}
