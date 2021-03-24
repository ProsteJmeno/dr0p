using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class nickname : MonoBehaviour
{
    public GameObject field;
    // Start is called before the first frame update
    void Start()
    {
        TMP_InputField text = field.GetComponent<TMP_InputField>();
        if (PlayerPrefs.HasKey("name"))
        {
            text.text = PlayerPrefs.GetString("name");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange (string name)
    {
        PlayerPrefs.SetString("name", name);
        PlayerPrefs.Save();
    }
}
