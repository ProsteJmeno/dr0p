using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneObstacles : MonoBehaviour
{
    public GameObject obstacle;

    public float cloneDelay;
    float lastCloneTime;

    private void Start()
    {
        Clone();
    }

    public void Update()
    {
        var actualTime = Time.time;
        if (actualTime >= lastCloneTime + cloneDelay)
        {
            Clone();
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
