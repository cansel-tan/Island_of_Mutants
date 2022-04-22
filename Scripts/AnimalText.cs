using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimalText : MonoBehaviour
{
    // Start is called before the first frame update
    Text textAnimal;
    public static int counterAnimal;

    void Start()
    {
        textAnimal = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textAnimal.text = counterAnimal.ToString();
    }
}
