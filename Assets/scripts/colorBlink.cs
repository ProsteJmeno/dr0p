using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorBlink : MonoBehaviour
{

    public float changeDuration;
    public GameObject text;

    private void Start()
    {
        StartCoroutine(ColorChange());
    }

    private IEnumerator ColorChange()
    {
        while (PlayerPrefs.GetInt("colors") != 1) { 
            yield return null;
            print("colors not 1");
        }
        while (PlayerPrefs.GetInt("colors") == 1)
        {
            
            yield return new WaitForSeconds(1);
            Color c = new Color(Mathf.Round(Random.Range(0, 255f)), Mathf.Round(Random.Range(0, 255f)), Mathf.Round(Random.Range(0, 255f)));
            print("color: " + c);
            Camera main = gameObject.GetComponent<Camera>();
            text.GetComponent<Image>().color = Color.Lerp(main.backgroundColor, c, 0.5f);
            main.backgroundColor = Color.Lerp(main.backgroundColor, c, 1f);
        }
       
    }


}
