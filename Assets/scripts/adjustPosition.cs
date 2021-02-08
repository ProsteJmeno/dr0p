using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustPosition : MonoBehaviour
{
    private void Awake()
    {
        gameObject.transform.position = new Vector2(Screen.width, Screen.height);
    }
}
