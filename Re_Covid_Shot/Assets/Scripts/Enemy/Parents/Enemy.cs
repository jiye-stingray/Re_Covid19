using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;
    public int HP
    {
        get => hp;
        set
        {
            hp = value;

            if(hp <= 0)
            {
                Dead();
            }
        }
    }
    public float speed;
    [SerializeField] protected GameObject bullet;
    public bool isBoss;
    public int power;
    [SerializeField] int score;     //처치 했을 때 플레이어에게 주는 점수
    public Vector3 moveVec;//아래로 내려가는 Enemy
    public Player player => Player.Instance;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        moveVec = Vector3.down;
    }

    /// <summary>
    /// 이동
    /// </summary>
    protected virtual void Update()
    {
        transform.Translate(speed * Time.deltaTime * moveVec);
    }

    /// <summary>
    /// 죽은 경우
    /// </summary>
    public virtual void Dead()
    {
        GameManager.Instance.enemyScore += score;       //몬스터에 할당된 점수만큼 점수 획득
        Destroy(gameObject);                            //오브젝트 삭제
    }

    /// <summary>
    /// 공격 코루틴
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator Attack()
    {
        yield return null;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if(bullet.myBullet == Bullet.BulletType.Player)     //충돌한 총알이 플레이어의 것이라면
            {
                anim.SetTrigger("isHit");
                HP -= Mathf.Max(0,bullet.power);    //총알의 공격력만큼 hp 감소
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))       //플레이어의 공격을 통과하고 벽에 부딪혔다면
        {
            if (isBoss)     //보스는 벽에 부딪혀도 괜찮다
                return;
            GameManager.Instance.Pain += (int)(power * 0.5f);       //플레이어의 고통게이지를 공격력의 절반만큼 증가

            Destroy(gameObject);
        }

    }

}
