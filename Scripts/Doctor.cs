using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class Doctor : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent doctorNavMesh;
    public float mesafe;
    public GameObject hedefOyuncu;
    public float görmeMesafesi;
    Animator doctorAnim;
    float finishTime = 3.0f;




    void Start()
    {
       doctorNavMesh = this.GetComponent<NavMeshAgent>();
        doctorAnim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        hedefOyuncu = GameObject.Find("oliver");
        mesafe = Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);

        

        if (mesafe < görmeMesafesi)
        {
            this.transform.LookAt(hedefOyuncu.transform.position);
            //doctorNavMesh.isStopped = true;
            //ko?ma
            doctorAnim.SetBool("slowrun", true);
          
            finishTime -= Time.deltaTime;
            if (finishTime < 0)
            {
                SceneManager.LoadScene(2);
                finishTime = 3.0f;
            }
            
           
            //gameover.gameObject.SetActive(true);
            
        } else
        {
          
            doctorAnim.SetBool("slowrun", false);
        }
        

       
    }
}
