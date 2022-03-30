using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] public float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] public int damage;
    
    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    
    [Header("Layer Mask")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTime = Mathf.Infinity;
    
    private Animator anim;
    private Player player;

  

    private Player playerHealth;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //An attack cooldown so the enemy doesn't spam attacks
        cooldownTime += Time.deltaTime;

        if (PlayerInSight())
        {
            //checks if the cooldown is less than the attack time
            if (cooldownTime >= attackCooldown)
            {
                //Reset the cooldown and play the attack animation
                cooldownTime = 0;
                anim.SetTrigger("Attack");
            }
        }

    }


   
    //Makes a raycast to detect if the player is in it moves with the enemy
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Player>();
        }
        return hit.collider != null;
    }

    //Draws it so I can easily mess with the settings
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        //Damages the player when the player is in the hit Detection of the ememy
        if (PlayerInSight())
        {
            playerHealth.takeDamage(damage);
        }
    }

   

   


   
}
