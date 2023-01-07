using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] TextMeshProUGUI textDisplay;


    public void PlayNotification(string text)
    {
        textDisplay.text = text;
        anim.SetTrigger("Play");
    }



}
