using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : BuffEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().Heal(amount);
    }

}
