using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7.5f;

    public Rigidbody2D myRigidbody2D;
    public CircleCollider2D feet;

    private float horizontalMovement = 0f;
    public int facing = 1;
    public LayerMask layerMask;
    public Animator animator;
    Health healthScript;
    bool isGrounded;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthScript.isAlive == false)
        {
            return;
        }

        CheckFacing();

        horizontalMovement = Input.GetAxis("Horizontal");
        isGrounded = feet.IsTouchingLayers(layerMask);
        if(!healthScript.isHit)
        {
            animator.SetBool("IsTouchingGround", isGrounded);
            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                if(!healthScript.isDummy)
                {
                    myRigidbody2D.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
                    animator.SetTrigger("Jump");
                }
            }
            
          /*if(feet.IsTouchingLayers(layerMask))
            {
                animator.SetBool("IsTouchingGround", true);
            }
            else{
                animator.SetBool("IsTouchingGround", false);
            }
            */
        }

    }

    private void CheckFacing()
    {
        Vector3 direction  = (enemy.position - transform.position).normalized;
        Debug.DrawRay(transform.position,direction, Color.green);
        
        if(healthScript.isDummy)
        {

        }
        else{
            Debug.Log("Direction: " + direction.x);
            if(facing == 1)
            {
               if(direction.x < -0.5f){
                   Flip();
               }
            }
            else{
                 if(direction.x > 0.5f){
                   Flip();
               }
            }
        }
    }

    private void Flip()
    {
        Debug.Log("Käänny");
        transform.localScale = new Vector2(transform.localScale.x *-1, transform.localScale.y);
        facing = (int)transform.localScale.x;
    }

    void FixedUpdate()
    {

        if(healthScript.isAlive == false)
        {
            return;
        }

        if(!healthScript.isHit)
        {
            if(!healthScript.isDummy)
            {
                myRigidbody2D.velocity = new Vector2(horizontalMovement * speed, myRigidbody2D.velocity.y);
                animator.SetFloat("Speed",Mathf.Abs(horizontalMovement));
            }
        }
    }
}
