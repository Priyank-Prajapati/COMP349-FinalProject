using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIpatrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkSpeed;
    public bool mustPatrol;
    public bool mustTurn;
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    void Start()
    {
        mustPatrol = true;
        walkSpeed = 50;
    }
    private void FixedUpdate()
    {
        if(mustPatrol )
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (mustPatrol)
        {
            Patrol();
        }
    }
    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(-walkSpeed * Time.fixedDeltaTime*2, rb.velocity.y);
    }
    void Flip()
    {
        mustTurn = false;
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
        
    }
    
}
