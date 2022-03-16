using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] int speed;
    public int power;

    Vector3 moveVec;

    public enum BulletType
    {
        Player,
        Enemy
    }

    public BulletType myBullet;

    // Start is called before the first frame update
    void Start()
    {
        switch (myBullet)
        {
            case BulletType.Player:
                moveVec = Vector3.up;
                break;
            case BulletType.Enemy:
                moveVec = Vector3.down;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate( moveVec * speed * Time.deltaTime);
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
