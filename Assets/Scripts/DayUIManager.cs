using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayUIManager : MonoBehaviour
{
    [SerializeField] string dayText;
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] GameObject modal;
    [SerializeField] MouseManager mouseManager;

    public void UpdateDayText()
    {
        textDisplay.text = resourceManager.GetResource("days") + " " + dayText;
    }

    public void ShowModal()
    {
        mouseManager.modalOpen = true;
        modal.SetActive(true);
    }

    public void DismissModal()
    {
        mouseManager.modalOpen = false;
        modal.SetActive(false);
    }

}
