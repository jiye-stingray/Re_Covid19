using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Item
{
    public override void Use()
    {

        if (player.isSpeedUpItem)
        {
            player.StopCoroutine(player.speedUpCoroutine);
        }
        player.speedUpCoroutine = player.StartCoroutine(player.SpeedUp());

        base.Use();
    }
}
