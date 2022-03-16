using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int HP;
    [SerializeField] int power;
    [SerializeField] int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if(bullet.myBullet == Bullet.BulletType.Player)
            {
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            //공격력의 절반 만큼 고통게이지 증가

            Destroy(gameObject);
        }
    }
}
