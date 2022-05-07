using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth;
    public int currentHealth;
   
    private Animator anim;
    private Rigidbody2D body;
    private MeleeEnemy buff;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;
    

    [Header("HealthBar")]
    public BossHealthBar healthBar;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        

        sprite = GetComponent<SpriteRenderer>();

        boxCollider = GetComponent<BoxCollider2D>();

        buff = GetComponent<MeleeEnemy>();
      

    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hit");

        healthBar.setHealth(currentHealth);

        //An enraged mode
        if (currentHealth <= maxHealth / 2)
        {
            //Decreases the attack cooldown and buffs the bosses damage 
            buff.attackCooldown = 0.25f;
            buff.damage = 40;
            //Represents a the enraged mode
            sprite.color = Color.yellow;
            

        }

        if(currentHealth <= 0)
        {
            Dead();
        }
        
            
        


    }
    private void Dead()
    {
    
        
            anim.SetBool("IsDead", true);
            boxCollider.enabled = false;
            body.bodyType = RigidbodyType2D.Static;
            healthBar.enabled = false;
            
        
       
    }

    private void DestoryBoss()
    {
        Destroy(gameObject);
    }

    private void Quit()
    {
        Application.Quit();
    }


}
