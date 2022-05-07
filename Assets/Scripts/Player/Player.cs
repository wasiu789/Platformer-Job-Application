using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthbar;

    [Header("Respawn")]
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    private Animator anim;
    private Rigidbody2D body;

    [Header("iframes")]
    [SerializeField] private float iframes;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private GameObject Checkpoint;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        spriteRend = GetComponent<SpriteRenderer>();
        
    }
    void Start()
    {
        currentHealth = maxHealth;
        Checkpoint = GameObject.Find("CheckPoint");
    }


    // Update is called once per frame
    void Update()
    {

        //Moves the fall detector to the players position
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);

        
    }

    //Plays the Death animation
    private void Die()
    {
        if (currentHealth <= 0)
        {
            anim.SetBool("IsDead", true);
        }




    }


    //Takes damage when the player collides with an enemy or is hit
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth >= 0)
        {
            anim.SetTrigger("Hit");
            StartCoroutine(Invunerability());

        }
        //sets the health bar after the player takes damage
        healthbar.setHealth(currentHealth);

        Die();


    }


    //When picking up a potion heals the player and restores the health bar
    public void Heal(int amount)
    {
        //Makes it so the player can't over heal over their max health
        if(currentHealth >= 100|| currentHealth > maxHealth)
        {
            amount = 0;
        }
        else
        {
            currentHealth += amount;
            //Moves the player healthbar back up
            healthbar.setHealth(currentHealth);
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.tag == "Fall Detector")
        {
            takeDamage(20);
            //Makes sure the player doesn't die from fall damage 
            if (currentHealth <= 20)
            {
                Heal(20);


            } 
            //moves the player back to the respawn point
            transform.position = respawnPoint;
            }
        else if(collision.tag == "Check Point")
        {
            respawnPoint = transform.position;
        }


        if (collision.tag == "Enemy")
        {
            takeDamage(10);
         }

        if(collision.tag == "Boss")
        {
            takeDamage(20);
        }

        if(collision.tag == "Next Level")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;
        }
        
    }

    private void StopMovement()
    {
        body.bodyType = RigidbodyType2D.Static;
    }
    
    //An iframes code
    public IEnumerator Invunerability()
    {

        //Ignores the collision for the player and enemy so the player doesn't take damage
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
           
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iframes / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iframes / (numberOfFlashes * 2));
        }
        //After the flashes and iframes are done the player can collide again
        Physics2D.IgnoreLayerCollision(8, 9, false);

        //Need to make it so the player also can't get hit by enemy attacks 



    }

    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }
    
}
