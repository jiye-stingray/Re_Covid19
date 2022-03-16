using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMove;
    float yMove;
    [SerializeField] int speed;
    [SerializeField] bool isInvisibility;


    Animator anim;
    SpriteRenderer sprite;

    [SerializeField] GameObject[] bullets;
    public int bulletLevel;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();

    }

    void FixedUpdate()
    {
        Move();

    }

    /// <summary>
    /// 움직임 함수
    /// </summary>
    void Move()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(xMove, yMove, 0) * speed * Time.deltaTime);

        anim.SetInteger("isMove",(int)xMove);
    }

    /// <summary>
    /// 발사 함수
    /// </summary>
    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullets[bulletLevel], transform.position, transform.rotation);

        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInvisibility)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                SystemManager.Instance.GameManager.HP -= (int)(enemy.power * 0.5f);
                StartCoroutine(Invisibility(1.5f, 1.5f));

            }
        }


    }

    /// <summary>
    /// 무적 상태를 나타내는 함수
    /// </summary>
    /// <param name="showTime">무적시간을 나타내는 효과가 지속되는 시간</param>
    /// <param name="realTIme">실제 무적 시간</param>
    /// <returns></returns>
    IEnumerator Invisibility(float showTime, float realTIme)
    {
        isInvisibility = true;
        sprite.color = new Color(1, 1, 1, 0.6f);
        yield return new WaitForSeconds(showTime);
        sprite.color = Color.white;
        yield return new WaitForSeconds(realTIme);
        isInvisibility = false;

    }

}
