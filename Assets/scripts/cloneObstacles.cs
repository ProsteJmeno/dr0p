using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float cloneDelay = 5;
    [Tooltip("Put here number lower than 1. Time will be multiplied by this numuber, so lower the number,"  +
        " less the time till cloning the obstacle.")]
    public float spawnRateMultiplier;
    public static float spawnTime;
    float lastCloneTime;
    float speedUpDelay;

    float lastSpeedTime;

    private void Start()
    {
        Clone();
        Debug.Log("clone on start");
        speedUpDelay = moveObstacles.defaultSpeedUpTime;
        lastSpeedTime = Time.time;
        lastCloneTime = Time.time;
    }

    public void Update()
    {
        var actualTime = Time.time;
        if (actualTime >= lastCloneTime + cloneDelay)
        {
            if (TimeBody.gameRunning)
            {
                lastCloneTime = Time.time;
                Clone();
                Debug.Log("Clone called");
            }
        }

        if(Time.time >= lastSpeedTime + speedUpDelay)
        {
            lastSpeedTime = Time.time;
            if (TimeBody.gameRunning)
            {
                cloneDelay = cloneDelay * spawnRateMultiplier;
                
                print("clone delay lowered: " + cloneDelay);
            }
        }

        if (cloneDelay < 1f)
        {
            cloneDelay = 1f;
            print("clone delay reached lowest value: " + cloneDelay);
        }
        spawnTime = cloneDelay;
    }

    public void Clone()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().enabled)
        {
            if (!rewindingBool.delayedRewind || TimeBody.gameRunning)
            {
                GameObject clone = Instantiate(obstacle);
                clone.transform.position = new Vector3(0, 15, 0);
                clone.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
                clone.tag = ("obstacle");
                
                print("cloned");
            }
        }
    }
}
