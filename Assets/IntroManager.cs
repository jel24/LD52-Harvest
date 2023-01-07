using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{

    [SerializeField] float howLong;
    [SerializeField] string sceneToLoad;

    float timer = 0;


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > howLong)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }




}
