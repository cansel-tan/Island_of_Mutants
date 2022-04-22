using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        MedicineText.counter += 1;
        Destroy(gameObject);
    }
}
