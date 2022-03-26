using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed;
    protected GameManager gameManager => GameManager.Instance;
    protected Player player => Player.Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public virtual void Use()
    {
        GameManager.Instance.itemCountScore += 10;
        Dead();
    }

    void Dead()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Use();
        }
    }
}
