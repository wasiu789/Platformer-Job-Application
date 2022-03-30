using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{ 

   [SerializeField] public float attackCooldown;
    [SerializeField] private Transform knifePoint;
    [SerializeField] private GameObject[] knives;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Upon pressing left click, checks if the player is grounded and not jumping and if the cooldownTimer is less than the attack cooldown 
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        //updates the cooldownTimer
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        //On Attack set play the animation and rest the cooldown timer
        anim.SetTrigger("Attack"); 
        cooldownTimer = 0;
        //Get a knife and reset the postion to fire point after every attack
        knives[findKnives()].transform.position = knifePoint.position;
        //Get a knife and send the knife in the direction the player is facing
        knives[findKnives()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    //
    private int findKnives()
    {
        //loops through the knives and if it is not active the player can shoot it out
        for(int i = 0; i < knives.Length; i++)
        {
            if(!knives[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
