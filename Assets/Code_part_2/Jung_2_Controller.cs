using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jung_2_Controller : AController
{
    public GameObject Jump_Stand;
    public override void Update()
    {
        if (isOver)
        {
            Jump_Stand.SetActive(false);
            frog.moving = false;
            return;
        }

        toNextScene();
    }
}
