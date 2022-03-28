using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float speed;
    public int power;

    public Vector3 moveVec;
    public Vector2 changeVec = Vector2.zero;

    public enum BulletType
    {
        Player,
        Enemy
    }

    public BulletType myBullet;

    void Start()
    {
        if (myBullet == BulletType.Player)
            moveVec = Vector3.up;
        else
            moveVec = Vector2.down;
    }

    void Update()
    {
        if (changeVec != Vector2.zero)
            transform.Translate(changeVec * speed * Time.deltaTime, Space.Self);
        else
            transform.Translate(moveVec * speed * Time.deltaTime, Space.Self);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if(myBullet == BulletType.Player)
            {
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            if (myBullet == BulletType.Enemy)
            {
                Destroy(gameObject);

            }
        }
    }
}
