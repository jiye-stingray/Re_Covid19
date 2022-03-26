using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainReduction : Item
{
    public override void Use()
    {
        gameManager.Pain -= 10;
        base.Use();
    }
}
