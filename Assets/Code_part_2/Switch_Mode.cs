using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Mode : MonoBehaviour
{
    public GameObject day, night;
    bool dayMode = false;
    Jung_1_Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Jung_1_Controller>();
    }
    public bool isDayMode()
    {
        return dayMode;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeMode()
    {
        if (dayMode)
        {
            day.SetActive(false);
            night.SetActive(true);
            dayMode = false;
        }
        else
        {
            day.SetActive(true);
            night.SetActive(false);
            dayMode = true;
        }
        controller.showHiddenLand();
    }
}
