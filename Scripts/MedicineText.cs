using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedicineText : MonoBehaviour
{
    // Start is called before the first frame update
     Text medicineText;
     
    
    public static int counter;
   

    void Start()
    {
        medicineText = GetComponent<Text>();
       

    }

    // Update is called once per frame
    void Update()
    {
        medicineText.text = counter.ToString();
      

    }
}
