using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
   


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    private void FixedUpdate()
    {
        //Get the Horizontal press from the user and moves the player
         horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed,body.velocity.y);


        //flips the player
        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale =  new Vector3(-1,1,1);
        }

        //Gets the space from the user and makes the player jump if the player is on the ground
        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }

        //Set animator paramtors
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", isGrounded());

        
       
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       

    }

    
    

    //Checks if the player is gorunded using a raycast
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null; 
    }
    //Checks if the player can Attack
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded();
    }
}
