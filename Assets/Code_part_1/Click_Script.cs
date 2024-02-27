using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Click_Script : MonoBehaviour
{
    public UnityEvent click;
    public bool repeat = false;

    private bool isClick = false;
    private bool clickCheck = true;

    // Update is called once per frame
    void Update()
    {
        if (isClick && clickCheck)
        {
            click.Invoke();
            clickCheck = false;
            if (repeat)
            {
                isClick = false;
                clickCheck = true;
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isClick) isClick = true;
    }
}
