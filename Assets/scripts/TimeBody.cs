using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class TimeBody : MonoBehaviour
{
    bool isRewinding = false;
    bool adShowing;
    string placement = "rewardedVideo";


    public GameObject[] HUD;
    public GameObject Waiting;
    public GameObject error;
    public countdown countdownTimer;

    public static bool hasBeenRevived = false;
    public static bool gameRunning = true;

    List<PointInTime> pointsInTime;
    
    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        Advertisement.Initialize("4022257");
        error.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (rewindingBool.shouldRewind)
        {
            StartRewind();
        }
        adShowing = Advertisement.isShowing;
    }
    public void StartRewind()
    {
        isRewinding = true;
        rewindingBool.delayedRewind = true;
        StartCoroutine(RewindLength());
    }
   

    public void reviveButton()
    {
        
        if (Advertisement.IsReady())
        {
            hasBeenRevived = true;
            Time.timeScale = 0;
            StartCoroutine(playAd());
            countdown.isRunning = false;
            countdownTimer.TimeReset();
            GameObject.FindGameObjectWithTag("deathScreen").SetActive(false);
            Waiting.SetActive(true);
        }
        else
        {
            error.SetActive(true);
            GameObject.FindGameObjectWithTag("deathScreen").SetActive(false);
        }
    }

    IEnumerator playAd()
    {
        Advertisement.Show(placement);
        yield return new WaitForSecondsRealtime(2);
        while (adShowing)       
            yield return null;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        Waiting.SetActive(false);
        foreach (GameObject o in HUD)
        {
            o.SetActive(true);
        }
        rewindingBool.shouldRewind = true;
    }

    private IEnumerator RewindLength()
    {
        yield return new WaitForSeconds(cloneObstacles.spawnTime-(cloneObstacles.spawnTime / 4));
        rewindingBool.shouldRewind = false;
        isRewinding = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Rigidbody>().isKinematic = false;
        gameRunning = true;
        yield return new WaitForSeconds(cloneObstacles.spawnTime - (cloneObstacles.spawnTime / 4));
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
        if (pointsInTime.Count > 1)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else if (pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
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
