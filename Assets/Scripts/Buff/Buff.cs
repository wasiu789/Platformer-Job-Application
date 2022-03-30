using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public BuffEffect buff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Apply the buff of the object the player collides with and then destorys it 
        if(collision.tag == "Player")
        {

            Destroy(gameObject);
            buff.Apply(collision.gameObject);


        }
    }
}
