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

}
