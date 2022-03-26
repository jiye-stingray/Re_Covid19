using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
    public override void Use()
    {
        gameManager.HP += 10;
        base.Use();
    }
}
