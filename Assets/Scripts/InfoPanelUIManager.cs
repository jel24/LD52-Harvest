using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class InfoPanelUIManager : MonoBehaviour
{
    [SerializeField] SelectionManager selectionManager;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI goldCost;
    [SerializeField] TextMeshProUGUI workerCost;
    [SerializeField] TextMeshProUGUI stoneCost;
    [SerializeField] TextMeshProUGUI crystalCost;

    [SerializeField] Image image;
    [SerializeField] GameObject panel;

    public void UpdateSelectionContent()
    {
        if (selectionManager.GetSelection())
        {
            Occupant selected = selectionManager.GetSelection().GetComponent<Occupant>();
            title.text = selected.occupantName.ToString();
            description.text = selected.description;
            goldCost.text = selected.goldCost.ToString();
            workerCost.text = selected.workerCost.ToString();
            stoneCost.text = selected.stoneCost.ToString();
            crystalCost.text = selected.crystalCost.ToString();

            //image.sprite = selected.icon;
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }


}
