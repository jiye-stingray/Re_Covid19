using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : NPC
{
    [SerializeField] int increseAmount;

    protected override void Use()
    {
        GameManager.Instance.Pain += increseAmount;
        base.Use();
    }
}
