using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    float xMove;
    float yMove;
    public float speed;
    public bool isInvisibility;

    [SerializeField] float fireTimer;
    [SerializeField] float fireDelay;

    GameManager gameManager => GameManager.Instance;

    Animator anim;
    SpriteRenderer sprite;

    [SerializeField] GameObject[] bullets;
    private int bulletLevel;
    AudioSource audio;

    public int BulletLevel
    {
        get => bulletLevel;
        set
        {
            bulletLevel = value;

            if (bulletLevel > 4)
                bulletLevel = 4;
            else if (bulletLevel < 0)
                bulletLevel = 0;
        }
    }


    public override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireCheck();
        ShowInvisibility();
        ShowSpeedUp();

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

        transform.Translate(new Vector3(xMove, yMove, 0) * speed * Time.fixedDeltaTime);

        anim.SetInteger("isMove",(int)xMove);
    }

    /// <summary>
    /// 발사 조건 확인
    /// </summary>
    void FireCheck()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetMouseButton(0) && fireTimer >= fireDelay)
        {
            Fire();
        }
    }

    /// <summary>
    /// 실질적 발사 함수
    /// </summary>
    void Fire()
    {
        audio.Play();
        Instantiate(bullets[bulletLevel], transform.position, transform.rotation);
        fireTimer = 0f;

    }

    void ShowInvisibility()
    {
        if(isInvisibility)
            sprite.color = new Color(1, 1, 1, 0.6f);
        else
            sprite.color = Color.white;

    }

    void ShowSpeedUp()
    {
        if (isSpeedUpItem)
            speed = 10;
        else
            speed = 5;
    }

    public bool isgodItem;      //코루틴 진행중을 알려주는 bool
    public Coroutine godCoroutine;  //무적 코루틴을 담아두는 코루틴 변수
    /// <summary>
    /// 무적 상태를 나타내는 함수
    /// </summary>
    /// <param name="showTime">무적시간을 나타내는 효과가 지속되는 시간</param>
    /// <param name="realTIme">실제 무적 시간</param>
    /// <returns></returns>
    public IEnumerator Invisibility(float showTime, float realTIme)
    {
        if (CheatController.Instance.isInvisbilityCheat)
            yield break;

        isgodItem = true;

        isInvisibility = true;
        yield return new WaitForSeconds(showTime);
        sprite.color = Color.white;
        yield return new WaitForSeconds(realTIme);

        if (CheatController.Instance.isInvisbilityCheat)
            yield break;
        isInvisibility = false;
        isgodItem = false;

    }

    public bool isSpeedUpItem;      //코루틴 진행중을 알려주는 bool
    public Coroutine speedUpCoroutine;      //스피드 업 코루틴을 담아두는 코루티 변수
   
    /// <summary>
    /// 2초간 스피드를 빠르게 한다
    /// </summary>
    /// <returns></returns>
    public IEnumerator SpeedUp()
    {
        isSpeedUpItem = true;
        yield return new WaitForSeconds(2f);
        isSpeedUpItem = false;

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInvisibility)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                gameManager.HP -= Mathf.Max(0, (int)(enemy.power * 0.5f));
                godCoroutine =  StartCoroutine(Invisibility(1.5f, 1.5f));


            }
            else if (collision.gameObject.CompareTag("Bullet"))
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                if(bullet.myBullet == Bullet.BulletType.Enemy)
                {
                    gameManager.HP -= Mathf.Max(0,(int)(bullet.power));
                    godCoroutine =  StartCoroutine(Invisibility(1.5f, 1.5f));

                }
            }


        }


    }


}
