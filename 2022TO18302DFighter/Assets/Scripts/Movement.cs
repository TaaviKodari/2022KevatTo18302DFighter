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
    Health healthScript;
    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if(!healthScript.isHit)
        {
            if(Input.GetButtonDown("Jump") && feet.IsTouchingLayers(layerMask)){
                myRigidbody2D.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        if(!healthScript.isHit)
        {
            myRigidbody2D.velocity = new Vector2(horizontalMovement * speed, myRigidbody2D.velocity.y);
        }
    }
}
