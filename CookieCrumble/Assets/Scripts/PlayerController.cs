using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private inspector variable
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private Transform groundCheckPos; //ground check overlapcircle position
    [SerializeField] private float groundCheckRadius; //ground check overlapcircle radius
    [SerializeField] private LayerMask whatIsGround; //ground Layer Mask

    //private variable
    private Rigidbody2D rBody;
    private bool isGrounded = false;
    private Animator anim;
    private bool isFacingRight = true;
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if on ground
        isGrounded = GroundCheck();
        //jump code
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
        }

        float horiz = Input.GetAxis("Horizontal");
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //check if sprite needs to be flipped
        if (isFacingRight && rBody.velocity.x < 0)
            Flip();
        else if (!isFacingRight && rBody.velocity.x > 0)
            Flip();

        //send value to animator
        //anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x)); //also horiz works
        //anim.SetFloat("ySpeed", Mathf.Abs(rBody.velocity.y));
        //anim.SetBool("isGrounded", isGrounded);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }
}
