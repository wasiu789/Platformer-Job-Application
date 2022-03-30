using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : BuffEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        //Makes sure the player speed doesn't execced a certain number
        if (target.GetComponent<PlayerMovement>().speed >= 20)
        {
            target.GetComponent<PlayerMovement>().speed += 0;
        }
        else 
        {
            target.GetComponent<PlayerMovement>().speed += amount;
        }
        
    }
}


