using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementManager : MonoBehaviour
{
    string placement = "rewardedVideo";

    IEnumerator Start()
    {
        Advertisement.Initialize("4022257", true);

        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show();
    }

    
}
