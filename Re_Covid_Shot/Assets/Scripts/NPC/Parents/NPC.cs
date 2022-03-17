using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float speed;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    protected virtual void Dead()
    {
        Destroy(gameObject);
    }

    protected virtual void Use()
    {
        Dead();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Dead();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Use();
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet.myBullet == Bullet.BulletType.Player)
            {
                Use();
            }
        }
    }
}
