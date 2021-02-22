using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioKeep : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("music");
        if (musicObjs.Length > 1)
        {
            Destroy(musicObjs[1]);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("music"));
    }
}
