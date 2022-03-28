using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 암세포는 유도탄을 쏜다
/// </summary>
public class CancerCell : Enemy
{
    protected override void Start()
    {
        StartCoroutine(Attack());
        base.Start();
    }

    protected override IEnumerator Attack()
    {
        for (int i = 0; i < 5; i++)
        {
            //유도탄
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            GameObject bullet = Instantiate(base.bullet, transform.position, transform.rotation);
            bullet.transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);      //총알의 회전각을 변경


            Bullet bulletLogic = bullet.GetComponent<Bullet>();
            bulletLogic.power = power;      //생성된 총알에 공격력을 적군의 공격력을 넣어준다

            yield return new WaitForSeconds(0.5f);
        }
    }
}
