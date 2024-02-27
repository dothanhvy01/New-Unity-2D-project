using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AController : MonoBehaviour
{
    public bool isOver;
    public bool isWin;
    public Scene sceneLoaded;
    public Frog_Movement frog;
    void Start()
    {
        isOver = false;
        isWin = false;
        sceneLoaded = SceneManager.GetActiveScene();
    }
    public abstract void Update();
    public void toNextScene()
    {
        if (isWin)
        {
            try
            {
                SceneManager.LoadScene(sceneLoaded.buildIndex + 1);
            }catch(Exception e)
            {
                Debug.Log(e.Message);

            }
        }
    }
}
