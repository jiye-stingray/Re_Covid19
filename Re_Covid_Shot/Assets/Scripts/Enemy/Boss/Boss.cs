using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{

    public bool isMiniBoss;

    public int MaxHP;
    public int attackIndex = 0;

    public GameObject[] spawnEnemy;
    public Transform[] spawnPos;

    protected override void Start()
    {
        HP = MaxHP;
        isBoss = true;
        StartCoroutine(Showing());
    }

    protected override void Update()
    {
        base.Update();
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

    /// <summary>
    /// 원형 탄막
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator CircleShot()
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

    /// <summary>
    /// 뱀꼬리 형태의 공격
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator SnakeShot()
    {
        int bulletCount = 51;

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

    /// <summary>
    /// 적군들 소환
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator SpawnEnemy()
    {
        Instantiate(spawnEnemy[Random.Range(0, spawnEnemy.Length)], spawnPos[0].position, spawnPos[0].rotation);
        Instantiate(spawnEnemy[Random.Range(0, spawnEnemy.Length)], spawnPos[1].position, spawnPos[1].rotation);

        yield return new WaitForSeconds(0.5f);
        attackIndex++;
        CheckAttack();
    }

    /// <summary>
    /// 죽은 경우
    /// </summary>
    public override void Dead()
    {

        if (!isMiniBoss)    //미니보스가 아닐때
        {
            BossManager.Instance.HPBar.enabled = false;
            BossManager.Instance.InstantiateMiniBoss();
            base.Dead();
            return;
        }
        else
        {
            //마지막 미니보스가 남았을 때
            if ((BossManager.Instance.mini1 != null && BossManager.Instance.mini2 != null))  //분열된 적중에 처음으로 죽었을 떄
            {
                BossManager.Instance.isLastMiniBoss = true;
            }
            else if (BossManager.Instance.isLastMiniBoss)   //모든 미니보스가 죽었을 때
            {
                BossManager.Instance.HPBar.enabled = false;
                StageFlow.Instance.EndStage();  //게임 끝
            }
        }

        base.Dead();
    }
}
