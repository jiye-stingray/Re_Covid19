using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float speed;

    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    void Update()
    {
    }

    protected void Dead()
    {
        Destroy(gameObject);
    }

    protected virtual void Use()
    {
        Dead();
    }

    IEnumerator MoveCoroutine()
    {

        while (true)
        {
            float timer = 0;
            float dirx = Random.Range(-1, 2);
            while (true)
            {
                timer += Time.deltaTime;

                Vector3 moveVec = new Vector3(dirx, -1, 0);

                transform.Translate(moveVec * speed * Time.deltaTime);
                if (timer > 0.5f)
                    break;

                yield return new WaitForEndOfFrame();

            }
        }

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
