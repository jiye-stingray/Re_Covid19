using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God : Item
{
    public override void Use()
    {
        if (player.isgodItem)
        {
            player.StopCoroutine(player.godCoroutine);
            Debug.Log("stop");
        }
         player.godCoroutine =  player.StartCoroutine(player.Invisibility(2.5f,3f));
        
        base.Use();
    }
}
