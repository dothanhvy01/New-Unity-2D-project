using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door_Scipt : MonoBehaviour
{
    private bool isOpen = false;
    private Animator an;

    // Start is called before the first frame update
    void Start()
    {
        an = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            an.Play("Door_open");
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
}
