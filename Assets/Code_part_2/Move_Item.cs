using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Item : MonoBehaviour
{
    public List<GameObject> listPosition;
    private int currentIndex = 0;
    Animator animator;
    public AnimationClip animation;
    public bool endMark;
    public bool enableToCLick = false;
    private void Start()
    {
        endMark = false;
        animator = GetComponent<Animator>();
    }

    public void MoveToPositions()
    {
      
        currentIndex = 0;

     
        StartCoroutine(MoveToNextPosition());
    }
    private void OnMouseDown()
    {
        if (enableToCLick)
        {
            MoveToPositions();
        }


    }
    private IEnumerator MoveToNextPosition()
    {
        while (currentIndex < listPosition.Count)
        {
            Vector3 nextPosition = listPosition[currentIndex].transform.position;

            
            while (Vector3.Distance(transform.position, nextPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime * 2.5f);
                yield return null;
            }

            currentIndex++;
        }
        PlaySpecialAnimation();
    }
    void PlaySpecialAnimation()
    {


        try
        {
            animator.SetBool("endmark", true);
            
            StartCoroutine(ReturnToDefaultState(animation.length));
           
        }
        catch(Exception e)
        {

        }
    }

    IEnumerator ReturnToDefaultState(float delay)
    {
        
        yield return new WaitForSeconds(delay/5);
        animator.SetBool("endmark", false);
        endMark = true;
      
    }
}


