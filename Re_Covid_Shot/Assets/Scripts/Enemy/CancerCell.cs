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
            //À¯µµÅº
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            GameObject bullet = Instantiate(base.bullet, transform.position, transform.rotation);
            bullet.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);


            Bullet bulletLogic = bullet.GetComponent<Bullet>();
            bulletLogic.power = power;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
