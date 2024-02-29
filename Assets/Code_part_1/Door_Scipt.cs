using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door_Scipt : MonoBehaviour
{
    private bool isOpen = false;
    private BoxCollider2D cl;
    private Animator an;

    // Start is called before the first frame update
    void Start()
    {
        cl = transform.GetComponent<BoxCollider2D>();
        an = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            an.Play("Door_open");
            cl.isTrigger = true;
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
}
