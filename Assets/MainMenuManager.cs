using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{


    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void NewGame()
    {
        SceneManager.LoadSceneAsync("Intro");
    }


    public void Quit()
    {
        Application.Quit();
    }

}
