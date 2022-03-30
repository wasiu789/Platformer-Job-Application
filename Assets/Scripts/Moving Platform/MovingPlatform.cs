using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public  float speed;
    public  int startingPoint;
    public Transform[] points;

    private int i;
    // Start is called before the first frame update
    void Start()
    {
        //Picks the position the platform wants to start at
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //checking the distance of the platform and the point
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; //increase the index
            if (i == points.Length) //checks if the platform was on the last point after index increase
            {
                i = 0;
            }
        }

        //Moves the platform
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    //Upon stepping on to the platform the gameOject will become a child 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    //Upon stepping off the platform the gameOject will no lonbger be a child; 

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
