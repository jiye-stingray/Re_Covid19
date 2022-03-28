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
    [SerializeField] int score;     //óġ ���� �� �÷��̾�� �ִ� ����
    public Vector3 moveVec;//�Ʒ��� �������� Enemy
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
    /// �̵�
    /// </summary>
    protected virtual void Update()
    {
        transform.Translate(speed * Time.deltaTime * moveVec);
    }

    /// <summary>
    /// ���� ���
    /// </summary>
    public virtual void Dead()
    {
        GameManager.Instance.enemyScore += score;       //���Ϳ� �Ҵ�� ������ŭ ���� ȹ��
        Destroy(gameObject);                            //������Ʈ ����
    }

    /// <summary>
    /// ���� �ڷ�ƾ
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
            if(bullet.myBullet == Bullet.BulletType.Player)     //�浹�� �Ѿ��� �÷��̾��� ���̶��
            {
                anim.SetTrigger("isHit");
                HP -= Mathf.Max(0,bullet.power);    //�Ѿ��� ���ݷ¸�ŭ hp ����
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))       //�÷��̾��� ������ ����ϰ� ���� �ε����ٸ�
        {
            if (isBoss)     //������ ���� �ε����� ������
                return;
            GameManager.Instance.Pain += (int)(power * 0.5f);       //�÷��̾��� ����������� ���ݷ��� ���ݸ�ŭ ����

            Destroy(gameObject);
        }

    }

}
