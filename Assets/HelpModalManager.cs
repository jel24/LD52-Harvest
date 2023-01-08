using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HelpModalManager : MonoBehaviour
{
    [SerializeField] MouseManager mouseManager;
    [SerializeField] GameObject modal;


    public void ShowModal()
    {
        mouseManager.modalOpen = true;

        modal.SetActive(true);
    }

    public void HideModal()
    {
        mouseManager.modalOpen = false;

        modal.SetActive(false);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

}
