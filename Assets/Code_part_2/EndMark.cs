using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMark : MonoBehaviour
{
    public AController controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller.isWin = true;
      
    }
}
