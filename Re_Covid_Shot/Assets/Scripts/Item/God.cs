using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : Item
{
    public override void Use()
    {
        player.StartCoroutine(player.Invisibility(2.5f,3f));
        
        base.Use();
    }
}
