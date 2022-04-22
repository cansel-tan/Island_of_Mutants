using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        Debug.Log("dsasdsa");
        SceneManager.LoadScene(1);
       

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        //StartScreen.gameObject.SetActive(false);

    }
}
