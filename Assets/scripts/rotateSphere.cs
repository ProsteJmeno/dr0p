using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class rotateSphere : MonoBehaviour
{
    GameObject target;
    public float rotateSpeed;
    public float speedIncreaseDelay;
    public float speedIncreaseDifference;
    public rotateClockwise rotateClockwise;
    public rotateCounterClockwise rotateCounterClockwise;
    float actualTime;
    float lastIncreaseTime;


    // Start is called before the first frame update
    void Start()
    {
        actualTime = Time.time;
        lastIncreaseTime = Time.time;
        target = GameObject.FindGameObjectWithTag("rotateTarget");
    }

    // Update is called once per frame
    void Update()
    {
        actualTime = Time.time;

        if (GetComponent<MeshRenderer>().enabled)
        {
            if (!rewindingBool.rewinding)
            {
                float direction = rotateClockwise.direction + rotateCounterClockwise.direction;
                gameObject.transform.RotateAround(target.transform.position, Vector3.up * direction, rotateSpeed * Time.deltaTime);
            }
        }
        if (actualTime > lastIncreaseTime + speedIncreaseDelay)
        {
            rotateSpeed += speedIncreaseDifference;
            lastIncreaseTime = Time.time;
            
        }
    }

    public void RotateClockwise()
    {
        gameObject.transform.RotateAround(target.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }

    public void RotateCounterClockwise()
    {
        gameObject.transform.RotateAround(target.transform.position, Vector3.down, rotateSpeed * Time.deltaTime);
    }

}
