using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jung_1_Controller : AController
{ 
    public GameObject hiddenLand;
    Switch_Mode switchMode;
    Land land;
    void Start()
    {
        isWin = false;
        sceneLoaded = SceneManager.GetActiveScene();
        isOver = false;
        switchMode = FindObjectOfType<Switch_Mode>();
        frog = FindObjectOfType<Frog_Movement>();
        land = FindObjectOfType<Land>();

    }
    public override void Update()
    {
        if (isOver)
        {
            frog.moving = false;
            return;
        }
        if (land.getIsEntered() && hiddenLand.activeSelf)
        {
            frog.moving = true;
        }
   
        toNextScene();
    }
    public void showHiddenLand()
    {
        if (switchMode.isDayMode())
        {
            hiddenLand.SetActive(true);
        }
        else
        {
            hiddenLand.SetActive(false);
        }
    }
}
