using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Item
{
    public override void Use()
    {
        // ��� ������ ����
        CheatController.Instance.AllEnemyDead(false);
        base.Use();
    }
}
