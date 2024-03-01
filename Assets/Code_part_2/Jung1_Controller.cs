using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jung1_Controller : AController
{
    PickExe pickExe;
    Key key;

    public override void Start()
    {
        pickExe = FindObjectOfType<PickExe>();
        key = FindObjectOfType<Key>();
    }

    public override void Update()
    {
        if (!key.canClick && pickExe.endMark)
        {
            key.canClick = true;
        }
    }
}
