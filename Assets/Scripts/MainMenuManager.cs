using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void StartButton()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
