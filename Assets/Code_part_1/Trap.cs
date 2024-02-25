using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Jung_1_Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Jung_1_Controller>();
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller.setIsOver(true);
        }
    }
}
