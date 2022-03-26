using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPHeal : Item
{
    public override void Use()
    {
        gameManager.HP += 10;
        base.Use();
    }
}
