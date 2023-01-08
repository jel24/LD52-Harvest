using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewDawnModalManager : MonoBehaviour
{

    public TextMeshProUGUI[] descriptions;
    public TextMeshProUGUI[] titles;

    public Image[] images;
    [SerializeField] NewDawnManager newDawnManager;
    [SerializeField] MouseManager mouseManager;
    public TriggeredEvent[] events;

    [SerializeField] GameObject modal;

    public void TakeOption(int whichOption)
    {
        events[whichOption].Trigger();
        newDawnManager.Increment(whichOption);
    }

    public void UpdateOptions()
    {
        events = newDawnManager.GetEvents();
        images[0].sprite = newDawnManager.GetImage(1);
        images[1].sprite = newDawnManager.GetImage(2);
        descriptions[0].text = newDawnManager.GetDescription(1);
        descriptions[1].text = newDawnManager.GetDescription(2);
        titles[0].text = newDawnManager.GetTitle(1);
        titles[1].text = newDawnManager.GetTitle(2);
    }

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


}
