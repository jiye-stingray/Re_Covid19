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
            //Target �������� �߻�� ������Ʈ ����
            var b1 = new List<Transform>();
            b1.Clear();

            for (int j = 0; j < 360; j += 13)
            {
                //�Ѿ� ����
                var temp = Instantiate(bullet);
                temp.transform.position = transform.position;

                //������ �Ŀ� Ÿ�ٿ��� ���ư� ������Ʈ ����
                b1.Add(temp.transform);

                //z�� ���� ���ؾ� ȸ���� �̷�����Ƿ� z�� j�� �����Ѵ�
                temp.transform.rotation = Quaternion.Euler(0, 0, j);

            }

            //�Ѿ��� Ÿ�� �������� �̵���Ų��
            StartCoroutine(BulletToTarget(b1));

            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(0.5f);
        attackIndex++;
        CheckAttack();

    }


    /// <summary>
    /// ���� ź��
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
    /// �첿�� ������ ����
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
    /// ������ ��ȯ
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
            if (b1[i] == null)  //������Ʈ�� �̵��ϱ� ���� �ı��Ǵ� ��Ȳ(���� �Ѿ� �ε����� ��)
                continue;

            //���� �Ѿ��� ��ġ���� �÷����� ��ġ�� ���Ͱ��� �����Ͽ� ������ ����
            target_dir = player.transform.position - b1[i].transform.position;

            //x, y�� ���� �����Ͽ� z �������� ������ -> ~�� ������ ����
            float angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;

            //Target �������� �̵�
            b1[i].rotation = Quaternion.AngleAxis(angle + 90,Vector3.forward);

        }
        b1.Clear();

        yield return new WaitForSeconds(0.5f);

    }
}
