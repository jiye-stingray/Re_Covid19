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
    /// ������ �Լ�
    /// </summary>
    void Move()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(xMove, yMove, 0) * speed * Time.fixedDeltaTime);

        anim.SetInteger("isMove",(int)xMove);
    }

    /// <summary>
    /// �߻� ���� Ȯ��
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
    /// ������ �߻� �Լ�
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

    public bool isgodItem;      //�ڷ�ƾ �������� �˷��ִ� bool
    public Coroutine godCoroutine;  //���� �ڷ�ƾ�� ��Ƶδ� �ڷ�ƾ ����
    /// <summary>
    /// ���� ���¸� ��Ÿ���� �Լ�
    /// </summary>
    /// <param name="showTime">�����ð��� ��Ÿ���� ȿ���� ���ӵǴ� �ð�</param>
    /// <param name="realTIme">���� ���� �ð�</param>
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

    public bool isSpeedUpItem;      //�ڷ�ƾ �������� �˷��ִ� bool
    public Coroutine speedUpCoroutine;      //���ǵ� �� �ڷ�ƾ�� ��Ƶδ� �ڷ�Ƽ ����
   
    /// <summary>
    /// 2�ʰ� ���ǵ带 ������ �Ѵ�
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
