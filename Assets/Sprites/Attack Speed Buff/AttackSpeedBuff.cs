using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/AttackSpeedBuff")]
public class AttackSpeedBuff : BuffEffect
{
    
    public float amount;
    public override void Apply(GameObject target)
    {
        //Makes it so the  attack cooldown of the player doesn't go lower than a certain amount 
        if (target.GetComponent<PlayerAttack>().attackCooldown >= .15)
        {
            target.GetComponent<PlayerAttack>().attackCooldown -= 0;
        }
        else
        {
            target.GetComponent<PlayerAttack>().attackCooldown -= amount;
        }
        
    }
}
