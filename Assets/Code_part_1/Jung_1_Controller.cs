using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jung_1_Controller : MonoBehaviour
{
    public GameObject hiddenLand;
    Switch_Mode switchMode;
    Frog_Movement frog;
    Land land;
    bool isOver;
    

    // Start is called before the first frame update
    void Start()
    {
        isOver = false;
        switchMode = FindObjectOfType<Switch_Mode> ();
        frog = FindObjectOfType<Frog_Movement> ();
        land = FindObjectOfType<Land> ();
       
    }

    public bool getIsOver()
    {
        return isOver;
    }
    public void setIsOver(bool value) {
        this.isOver = value; 
    }
    void Update()
    {
        if (isOver)
        { 
            frog.moving = false;
            return;
        }
        if (land.getIsEntered() && hiddenLand.activeSelf)
        {
            frog.moving = true;
            return;
        }
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
