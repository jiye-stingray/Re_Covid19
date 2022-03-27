using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White : NPC
{
    [SerializeField] GameObject[] items;

    protected override void Use()
    {
        ItemSpawn();

        base.Use();
    }

    void ItemSpawn()
    {
        Instantiate(items[Random.Range(0, items.Length)], transform.position, transform.rotation);
    }


}
