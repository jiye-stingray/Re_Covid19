using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMove;
    float yMove;

    [SerializeField] int speed;
    [SerializeField] Animator anim;

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


}
