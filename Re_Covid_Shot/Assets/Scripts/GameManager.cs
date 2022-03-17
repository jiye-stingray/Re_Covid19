using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool isGameOver;

    private int hp;
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

    private int pain;
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
    public const int MaxPain = 100;


    void GameOver()
    {
        isGameOver = true;
        //∞‘¿” æ¿ ≥°
    }



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
