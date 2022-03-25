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
                break;
            case 2:
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
    }


    public override void Dead()
    {

        //°ÔÀÓ ³¡
        StageFlow.Instance.EndStage();

        base.Dead();
    }
}
