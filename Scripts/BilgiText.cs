using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BilgiText : MonoBehaviour
{
    private Text bilgiContent;


    public static string textBilgi = "";


    void Start()
    {
        bilgiContent = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        bilgiContent.text = textBilgi.ToString();


    }
}
