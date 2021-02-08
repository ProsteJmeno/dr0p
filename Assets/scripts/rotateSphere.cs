using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSphere : MonoBehaviour
{
    GameObject target;
    public float rotateSpeed;
    public float speedIncreaseDelay;
    public float speedIncreaseDifference;
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
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    gameObject.transform.RotateAround(target.transform.position, Vector3.down, rotateSpeed * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    gameObject.transform.RotateAround(target.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
                }
            }
        }
        if (actualTime > lastIncreaseTime + speedIncreaseDelay)
        {
            rotateSpeed += speedIncreaseDifference;
            lastIncreaseTime = Time.time;
        }
    }
}
