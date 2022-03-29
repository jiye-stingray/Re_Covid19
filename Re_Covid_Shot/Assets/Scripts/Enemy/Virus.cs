using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
{
    float dashSpeed = 10f;
    protected override void Start()
    {
        StartCoroutine(Dash());
        StartCoroutine(Attack());
        base.Start();
    }

    IEnumerator Dash()
    {
        float temp = speed;
        yield return new WaitForSeconds(0.3f);
        speed = dashSpeed;
        yield return new WaitForSeconds(0.3f);
        speed = temp;
    }


    protected override IEnumerator Attack()
    {
        Vector3 moveVec =  player.transform.position -  transform.position;

        GameObject bullet =  Instantiate(base.bullet, transform.position, transform.rotation);
        Bullet bulletLogic = bullet.GetComponent<Bullet>();

        bulletLogic.power = power;

        yield return null;
        
    }
}
