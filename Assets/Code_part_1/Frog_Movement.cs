using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator an;
    private bool isGrounded = false;
    private bool isJumping = false;
    private string currentAnimationState;
    private Collider2D cl;

    public LayerMask groundLayer;
    public float jumpForce = 5f;
    public float moveSpeed = 5f;
    public float idleTime = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        cl = GetComponent<Collider2D>();    
    }

    void Update()
    {
        // Kiểm tra xem nhân vật có chạm đất không
        isGrounded = Physics2D.IsTouchingLayers(cl, groundLayer);

        // Nhảy khi nhấn phím Enter và nhân vật đang chạm đất và không đang nhảy
        if (Input.GetKeyDown(KeyCode.Return) && isGrounded && !isJumping)
        {
            isJumping = true;
            rb.velocity = new Vector2(moveSpeed, jumpForce); // Nhảy về phía bên phải
            ChangeAnimationState("Frog_jump"); // Chạy animation nhảy
        }

        // Nếu nhân vật đang chạm đất và đang nhảy
        if (isGrounded && isJumping)
        {
            ChangeAnimationState("Frog_idle"); // Dừng animation nhảy
            isJumping = false; // Đặt lại cờ nhảy

            // Gọi hàm nghỉ 1 giây trước khi nhảy tiếp
            Invoke("JumpAfterDelay", idleTime);
        }
    }

    void JumpAfterDelay()
    {
        // Nếu đang chạm đất và không đang nhảy
        if (isGrounded && !isJumping)
        {
            isJumping = true;
            rb.velocity = new Vector2(moveSpeed, jumpForce); // Nhảy về phía bên phải
            ChangeAnimationState("Frog_jump"); // Chạy animation nhảy
        }
    }
    void ChangeAnimationState(string newAnimationState)
    {
        if (currentAnimationState == newAnimationState) return;

        an.Play(newAnimationState);

        currentAnimationState = newAnimationState;
    }
}
