using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float cloneDelay = 5;
    [Header("Put here number lower than 1. Time will be multiplied bz this numuber, so lower the number," +
        " less the time till cloning the obstacle.")]
    public float spawnRateMultiplier;
    float lastCloneTime;
    float speedUpDelay;

    float lastSpeedTime;

    private void Start()
    {
        Clone();
        speedUpDelay = moveObstacles.defaultSpeedUpTime;
        lastSpeedTime = Time.time;
    }

    public void Update()
    {
        var actualTime = Time.time;
        if (actualTime >= lastCloneTime + cloneDelay)
        {
            Clone();
        }

        if(Time.time >= lastSpeedTime + speedUpDelay)
        {
            cloneDelay = cloneDelay * spawnRateMultiplier;
            lastSpeedTime = Time.time;
            print("clone delay lowered: " + cloneDelay);
        }

        if (cloneDelay < 1f)
        {
            cloneDelay = 1f;
            print("clone delay reached lowest value: " + cloneDelay);
        }
    }

    public void Clone()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().enabled)
        {
            if (!rewindingBool.delayedRewind)
            {
                GameObject clone = Instantiate(obstacle);
                clone.transform.position = new Vector3(0, 15, 0);
                clone.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
                clone.tag = ("obstacle");
                lastCloneTime = Time.time;
            }
        }
    }
}
