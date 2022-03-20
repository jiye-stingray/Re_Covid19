using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
{

    void Start()
    {
        StartCoroutine(Attack());
    }


    protected override IEnumerator Attack()
    {
        //Vector3 moveVec =  player.transform.position -  transform.position;

        GameObject bullet =  Instantiate(base.bullet, transform.position, transform.rotation);
        Bullet bulletLogic = bullet.GetComponent<Bullet>();

        bulletLogic.power = power;
        //bulletLogic.moveVec = moveVec;

        yield return null;
        
    }
}
