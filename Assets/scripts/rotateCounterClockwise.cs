using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class rotateCounterClockwise : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static float direction = 0f;
    public GameObject player;

    private void Start()
    {
        direction = 0f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        direction = -1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = 0f;
    }

}
