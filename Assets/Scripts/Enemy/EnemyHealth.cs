using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    private Animator anim;
    private Rigidbody2D body;
    private BoxCollider2D boxcollider;


    private DropItem drops;

   
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        drops = GetComponent<DropItem>();
        boxcollider = GetComponent<BoxCollider2D>();

    }

    void Start()
    {
        maxHealth = currentHealth;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void takeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hit");

        if(currentHealth <= 0 )
        {
            Dead();
            //Check if one of the random numbers generated isn't a null
            if (drops != null)
            {
                //Then drops the item the within that number range
                drops.DropItems();
                Debug.Log("Dropped an Item" + drops);
            }
           
            

        }

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hit");
        }
    }

    //Plays the death animation and Disables the box collider and stops the patrolling of the enemy
    public void Dead()
    {
        anim.SetBool("IsDead", true);
        boxcollider.enabled = false;
        body.GetComponent<AIPatrol>().enabled = false;
   

    }

  
    //Put as an event to happen after the enemy animation to destory it. 
    private void DestoryEnemy()
    {
        gameObject.SetActive(false);
    }



}
