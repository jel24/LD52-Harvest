using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceUIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI[] resourceFields;
    [SerializeField] ResourceManager resourceManager;

    public void UpdateValues()
    {
        resourceFields[0].text = resourceManager.GetResource("gold").ToString();
        resourceFields[1].text = resourceManager.GetResource("workers").ToString() + " / " + resourceManager.GetResource("shelter").ToString();
        resourceFields[2].text = resourceManager.GetResource("food").ToString();
        resourceFields[3].text = resourceManager.GetResource("stone").ToString();
        resourceFields[4].text = resourceManager.GetResource("crystal").ToString(); 
        resourceFields[5].text = "(+" + resourceManager.GetResource("foodIncome").ToString() + ")";
        resourceFields[6].text = "(+" + resourceManager.GetResource("goldIncome").ToString() + ")";
        resourceFields[7].text = "(+" + resourceManager.GetResource("stoneIncome").ToString() + ")";
        resourceFields[8].text = "(+" + resourceManager.GetResource("crystalIncome").ToString() + ")";

    }

}
