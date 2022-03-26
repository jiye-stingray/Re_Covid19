using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Item
{
    public override void Use()
    {
        // 모든 적군을 죽임
        CheatController.Instance.AllEnemyDead(false);
        base.Use();
    }
}
