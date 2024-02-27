using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject entrance, exit;
    Frog_Movement frog_Movement;
    Animator animator;
    public bool touch = false;
    void Start()
    {
        frog_Movement = FindObjectOfType<Frog_Movement>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }
    IEnumerator ResetAnimation(Collision2D collision)
    {
        
        collision.gameObject.SetActive(false);

        Vector3 currentScale = collision.gameObject.transform.localScale;
        currentScale.x *= -1;
        collision.gameObject.transform.localScale = currentScale;
        collision.gameObject.transform.position = exit.transform.position;
        frog_Movement.isFacingRight = false;
        collision.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        animator.SetBool("touch", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("touch", true);
            if (gameObject.CompareTag(entrance.tag))
            {
                StartCoroutine(ResetAnimation(collision));


            }
          
           
        }
      
    }
}
