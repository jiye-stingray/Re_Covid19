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
    public bool isBoss = true;

    public int power;

    [SerializeField] int score;

    public Player player => Player.Instance;

    protected virtual void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public virtual void Dead()
    {
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
                GameManager.Instance.score += score;
                HP -= Mathf.Max(0,bullet.power);
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            if (isBoss)
                return;

            GameManager.Instance.Pain += Mathf.Min((int)(power * 0.5f),100);

            Dead();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.score += score;
            Dead();
        }

    }

}
