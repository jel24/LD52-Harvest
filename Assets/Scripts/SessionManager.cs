using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{

    [SerializeField] ResourceManager resourceManager;
    [SerializeField] SelectionManager selectionManager;
    [SerializeField] HexManager hexManager;

    [SerializeField] TriggeredEvent dayPassEvent;


    void Start()
    {
        selectionManager.ClearSelection();
        hexManager.NewGame();
        resourceManager.Init();
    }

    public void EndDay()
    {
        resourceManager.SpendResource("days", 1);
        if (resourceManager.GetResource("days") == 0)
        {
            if (CheckVictory())
            {
                SceneManager.LoadSceneAsync("Victory");
            } else
            {
                SceneManager.LoadSceneAsync("Defeat");

            }
        }
        if (CheckVictory())
        {
            SceneManager.LoadSceneAsync("Victory");

        }
        dayPassEvent.Trigger();

    }

    bool CheckVictory()
    {
        if (resourceManager.GetResource("crystal") >= 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
