using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Movement : MonoBehaviour
{
    public LayerMask groundLayer;
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    public float jumpDelayTime = 1f;
    public bool moving = false;
    public float groundChackDistance = 0.1f;
    public GameObject deadPrefab;

    private Rigidbody2D rb;
    private Animator an;
    private bool isGrounded = false;
    private float jumpCooldown = 0.8f;
    private float lastJumpTime = 0f;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        an = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if (moving && Time.time - lastJumpTime >= jumpCooldown)
        {
            GroundCheck();
            if (isGrounded)
            {
                Jump();
                lastJumpTime = Time.time;
            }
        }
    }
    private void FixedUpdate()
    {
        an.SetFloat("yVelocity", rb.velocity.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(moveSpeed, jumpForce);
            an.SetBool("isJumping", true);
        }
    }

    void GroundCheck()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundChackDistance, groundLayer);

        if (hit.collider != null) isGrounded = true;

        else isGrounded = false;
    }

    private void OnMouseDown()
    {
        moving = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlockObject"))
        {
            BlockEvent();
        }
        if (collision.CompareTag("DeadObject"))
        {
            DeathEvent();
        }
    }

    void DeathEvent()
    {
        transform.gameObject.SetActive(false);
        GameObject newObject = Instantiate(deadPrefab, transform.position, Quaternion.identity);
        float randomXVelocity = Random.Range(-5f, 5f);
        float randomYVelocity = Random.Range(8f, 10f);

        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(randomXVelocity, randomYVelocity);
        }
    }

    void BlockEvent()
    {

    }
}
