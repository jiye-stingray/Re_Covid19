using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{

    [SerializeField] int MaxHP;
    int attackIndex = 0;

    [SerializeField] GameObject spawnEnemy;

    [SerializeField] Transform[] spawnPos;

    [SerializeField] Image HPBar;

    void Start()
    {
        HP = MaxHP;
        isBoss = true;
        StartCoroutine(Showing());
    }

    protected override void Update()
    {
        HPBarShow();
    }
    void HPBarShow()
    {
        HPBar.fillAmount = (float)HP / MaxHP;
    }

    IEnumerator Showing()
    {
        yield return new WaitForSeconds(2f);

        speed = 0;

        CheckAttack();

    }

   

    void CheckAttack()
    {
        if(attackIndex == 3)
            attackIndex = 0;

        switch (attackIndex)
        {
            case 0:
                StartCoroutine(SnakeTailAttack());
                break;
            case 1:
                StartCoroutine(CircleAttack());
                break;
            case 2:
                StartCoroutine(SpawnEnemy());
                break;
            default:
                break;
        }


    }

    IEnumerator SnakeTailAttack()
    {
        int bulletCount = 101;

        for (int i = 0; i < bulletCount; i++)
        {
            Vector2 vec = new Vector2(Mathf.Cos(Mathf.PI * 10 * i / bulletCount), -1);

            GameObject bullet = Instantiate(base.bullet,transform.position,transform.rotation);
            Bullet bulletLogic = bullet.GetComponent<Bullet>();
            bulletLogic.power = power;
            bulletLogic.moveVec = vec;

            yield return new WaitForSeconds(0.3f);

        }
        attackIndex++;
        CheckAttack();
    }

    IEnumerator CircleAttack()
    {
        int bulletCount = 50;

        for (int i = 0; i < bulletCount; i++)
        {
            Vector2 vec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / bulletCount), Mathf.Sin(Mathf.PI * 2 * i / bulletCount));

            GameObject bullet = Instantiate(base.bullet, transform.position, transform.rotation);
            Bullet bulletLogic = bullet.GetComponent<Bullet>();
            bulletLogic.power = power;
            bulletLogic.moveVec = vec;

        }
        yield return new WaitForSeconds(0.1f);
        attackIndex++;
        CheckAttack();
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(spawnEnemy, spawnPos[0].position, spawnPos[0].rotation);
            Instantiate(spawnEnemy, spawnPos[1].position, spawnPos[1].rotation);

            yield return new WaitForSeconds(0.5f);
        }
        attackIndex++;
        CheckAttack();
    }


}
