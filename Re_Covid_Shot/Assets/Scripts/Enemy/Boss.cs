using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{

    [SerializeField] int MaxHP;
    public int attackIndex = 0;

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
        base.Update();
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

   

    public virtual void CheckAttack()
    {
        if(attackIndex == 3)
            attackIndex = 0;

        switch (attackIndex)
        {
            case 0:
                StartCoroutine(CircleShot());
                break;
            case 1:
                StartCoroutine(SnakeShot());
                break;
            case 2:
                StartCoroutine(SpawnEnemy());
                break;
            default:
                break;
        }


    }

    IEnumerator CircleShot()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 360; j += 13)
            {
                GameObject Bullet = Instantiate(this.bullet);
                Bullet.transform.position = transform.position;
                Bullet.transform.rotation = Quaternion.Euler(0, 0, j);
            }

            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(0.5f);

        attackIndex++;
        CheckAttack();
    }

    IEnumerator SnakeShot()
    {
        int bulletCount = 101;

        for (int i = 0; i < bulletCount; i++)
        {
            Vector2 vec = new Vector2(Mathf.Cos(Mathf.PI * 10 * i / bulletCount), -1);


            GameObject bullet = Instantiate(this.bullet,transform.position,transform.rotation);
            Bullet logic = bullet.GetComponent<Bullet>();
            logic.changeVec = vec;


            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);
        attackIndex++;
        CheckAttack();

    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(spawnEnemy, spawnPos[0].position, spawnPos[0].rotation);
            Instantiate(spawnEnemy, spawnPos[1].position, spawnPos[1].rotation);

            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(0.5f);
        attackIndex++;
        CheckAttack();
    }

    public override void Dead()
    {

        //���� ��
        StageFlow.Instance.EndStage();

        base.Dead();
    }
}
