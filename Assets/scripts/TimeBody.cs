using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class TimeBody : MonoBehaviour
{
    bool isRewinding = false;
    string placement = "rewardedVideo";

    List<PointInTime> pointsInTime;
    
    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        Advertisement.Initialize("4022257");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartRewind();
        
        }

        void StartRewind()
        {
            isRewinding = true;
            rewindingBool.delayedRewind = true;
            StartCoroutine(RewindLength());
        }

    }

    public void reviveButton()
    {
       
    }

    private IEnumerator RewindLength()
    {
        yield return new WaitForSeconds(3f);
        isRewinding = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(3f);
        rewindingBool.delayedRewind = false;
    }


    private void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Rewind()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<MeshRenderer>().enabled = true;
        print(player.GetComponent<Rigidbody>().velocity);
        if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
    }
    void Record()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>().enabled)
        {
            if (pointsInTime.Count > Mathf.Round(4f / Time.fixedDeltaTime))
            {
                pointsInTime.RemoveAt(pointsInTime.Count - 1);
            }
            pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        }
    }
}
