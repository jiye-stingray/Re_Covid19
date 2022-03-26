using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    public override void Use()
    {
        if(player.BulletLevel < 4)
            player.BulletLevel++;
        base.Use();
    }
}
