using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlus : Boss
{
    public override void CheckAttack()
    {
        if (attackIndex == 4)
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
            case 3:
                StartCoroutine(Circle_goto());
                break;
            default:
                break;
        }
    }

    IEnumerator Circle_goto()
    {
        for (int i = 0; i < 3; i++)
        {
            //Target 방향으로 발사될 오브젝트 수록
            var b1 = new List<Transform>();
            b1.Clear();

            for (int j = 0; j < 360; j += 13)
            {
                //총알 생성
                var temp = Instantiate(bullet);
                temp.transform.position = transform.position;

                //딜레이 후에 타겟에게 날아갈 오브젝트 수록
                b1.Add(temp.transform);

                //z의 값이 변해야 회전이 이루어지므로 z에 j를 대입한다
                temp.transform.rotation = Quaternion.Euler(0, 0, j);

            }

            //총알을 타겟 방향으로 이동시킨다
            StartCoroutine(BulletToTarget(b1));

            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(0.5f);
        attackIndex++;
        CheckAttack();

    }


    /// <summary>
    /// 원형 탄막
    /// </summary>
    /// <returns></returns>
    public override IEnumerator CircleShot()
    {
        for (int i = 0; i < 5; i++)
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
    public override IEnumerator SnakeShot()
    {
        int bulletCount = 51;

        for (int i = 0; i < bulletCount; i++)
        {
            Vector2 vec = new Vector2(Mathf.Cos(Mathf.PI * 10 * i / bulletCount), -1);


            GameObject bullet = Instantiate(this.bullet, transform.position, transform.rotation);
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
    public override IEnumerator SpawnEnemy()
    {
        for (int i = 0; i <  3; i++)
        {
            Instantiate(spawnEnemy[Random.Range(0, spawnEnemy.Length)], spawnPos[0].position, spawnPos[0].rotation);
            Instantiate(spawnEnemy[Random.Range(0, spawnEnemy.Length)], spawnPos[1].position, spawnPos[1].rotation);

            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(0.5f);
        attackIndex++;
        CheckAttack();
    }


    Vector3 target_dir;

    IEnumerator BulletToTarget(List<Transform> b1)
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < b1.Count; i++)
        {
            if (b1[i] == null)  //오브젝트가 이동하기 전에 파괴되는 상황(벽에 총알 부딪히기 등)
                continue;

            //현재 총알의 위치에서 플레이의 위치를 벡터값을 뺄셈하여 방향을 구함
            target_dir = player.transform.position - b1[i].transform.position;

            //x, y의 값을 조합하여 z 방향으로 변형함 -> ~도 단위로 변형
            float angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;

            //Target 방향으로 이동
            b1[i].rotation = Quaternion.AngleAxis(angle + 90,Vector3.forward);

        }
        b1.Clear();

        yield return new WaitForSeconds(0.5f);

    }
}
