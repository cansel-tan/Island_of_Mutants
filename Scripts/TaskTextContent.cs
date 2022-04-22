using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskTextContent : MonoBehaviour
{
    private Text taskContent;


    public static string textContent="";


    void Start()
    {
        taskContent = GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        taskContent.text = textContent.ToString();


    }
}
