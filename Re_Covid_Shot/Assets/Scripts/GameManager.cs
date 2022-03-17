using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int hp;
    bool isGameOver;

    public int HP
    {
        get => hp;
        set
        {
            hp = value;
            if(hp <= 0 && !isGameOver)
            {
                GameOver();
            }
        }
    }
    public const int MaxHP = 100;
    public int pain;
    public int Pain
    {
        get => pain;
        set
        {
            pain = value;
            if(pain >= 100 && !isGameOver)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        isGameOver = true;
        //∞‘¿” æ¿ ≥°
    }

    public const int MaxPain = 100;


    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        pain = (int)(MaxPain * 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
