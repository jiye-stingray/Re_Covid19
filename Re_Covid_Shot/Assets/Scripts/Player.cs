using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMove;
    float yMove;

    [SerializeField] int speed;
    Animator anim;

    [SerializeField] GameObject[] bullets;
    public int bulletLevel;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireCheck();

    }

    void FixedUpdate()
    {
        Move();

    }

    void Move()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(xMove, yMove, 0) * speed * Time.deltaTime);

        anim.SetInteger("isMove",(int)xMove);
    }

    void FireCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullets[bulletLevel], transform.position, transform.rotation);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //무적 상태

            //몬스터의 공격력 절반 만큼 체력 감소
        }
    }

}
