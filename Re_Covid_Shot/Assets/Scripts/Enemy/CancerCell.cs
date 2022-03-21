using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancerCell : Enemy
{
    private void Start()
    {
        StartCoroutine(Attack());
    }

    protected override IEnumerator Attack()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 moveVec = player.transform.position - transform.position;

            GameObject bullet = Instantiate(base.bullet, transform.position, transform.rotation);
            Bullet bulletLogic = bullet.GetComponent<Bullet>();

            bulletLogic.moveVec = moveVec;
            bulletLogic.power = power;

            yield return new WaitForSeconds(1f);
        }
    }
}
