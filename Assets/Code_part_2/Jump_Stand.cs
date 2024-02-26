using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Stand : MonoBehaviour
{
    public GameObject jumpArrow, standArrow;
    public bool isJump;
    private Frog_Movement frogMovement;
    void Start()
    {
        isJump = false;
        frogMovement = FindObjectOfType<Frog_Movement>();
    }

    public void UporStand()
    {
        if (isJump)
        {
            standArrow.SetActive(false);
            jumpArrow.SetActive(true);
            frogMovement.moving = false;
            isJump = false;
        }
        else
        {
            standArrow.SetActive(true);
            jumpArrow.SetActive(false);
            frogMovement.moving = true;
            isJump = true;
        }
       
    }
}
