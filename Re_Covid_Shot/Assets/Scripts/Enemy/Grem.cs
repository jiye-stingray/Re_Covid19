using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grem : Enemy
{
    void Start()
    {
        StartCoroutine(Attack());
    }

    protected override IEnumerator Attack()
    {
        for (int i = 0;i < 3 ;i++)
        {

            GameObject bullet = Instantiate(base.bullet, transform.position, transform.rotation);

            Bullet bulletLogic = bullet.GetComponent<Bullet>();

           bulletLogic.power = this.power;
           bulletLogic.moveVec = Vector3.down;


            yield return new WaitForSeconds(0.5f);
        }

    }
}
