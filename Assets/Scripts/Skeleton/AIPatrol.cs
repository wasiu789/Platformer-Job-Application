using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public float speed;
    private Animator anim; 
    private bool movingRight = true;

    public Transform groundDetection;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        //Makes the Enemy move right and runs the animation
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        anim.SetBool("Run", true);

        //Send a raycast to hit the ground object
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);



        if(groundInfo.collider == false)
        {
            //Checks if the enemy is moving right
            if (movingRight == true)
            {
                //turns the character is moving right and then turns around to walk the other way
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                //If the charcter is moving left and reaches the edge turn the charcter to move back right
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

}
