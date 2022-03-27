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

    public Vector3 changeVec = Vector3.zero;
    Vector3 moveVec = Vector3.down;

    public Player player => Player.Instance;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected virtual void Start()
    {

    }

    /// <summary>
    /// 이동
    /// </summary>
    protected virtual void Update()
    {

        transform.Translate(moveVec * speed * Time.deltaTime);
    }

    public virtual void Dead()
    {
        GameManager.Instance.enemyScore += score;
        Destroy(gameObject);
    }

    protected virtual IEnumerator Attack()
    {
        yield return null;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if(bullet.myBullet == Bullet.BulletType.Player)
            {
                anim.SetTrigger("isHit");
                HP -= Mathf.Max(0,bullet.power);
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            if (isBoss)
                return;
            GameManager.Instance.Pain += (int)(power * 0.5f);

            Destroy(gameObject);
        }

    }

}
