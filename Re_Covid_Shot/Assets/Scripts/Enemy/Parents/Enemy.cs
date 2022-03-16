using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int HP;
    [SerializeField] int speed;
    [SerializeField] protected GameObject bullet;

    public int power;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if(HP <= 0)
        {
            Dead();
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    protected void Dead()
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
                HP -= bullet.power;
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            SystemManager.Instance.GameManager.pain += (int)(power * 0.5f);

            Dead();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Dead();
        }

    }

}
