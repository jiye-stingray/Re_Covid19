using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool isGameOver;

    [SerializeField] private int hp;
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
            else if(hp >= 100)
            {
                hp = 100;
            }
        }
    }
    public const int MaxHP = 100;

    [SerializeField] private int pain;
    public int Pain
    {
        get => pain;
        set
        {
            pain = value;
            if(pain >= MaxPain && !isGameOver)
            {
                GameOver();
            }
            else if(pain < 0)
            {
                pain = 0;
            }
        }
    }
    public const int MaxPain = 100;


    void GameOver()
    {
        isGameOver = true;
        //°ÔÀÓ ¾À ³¡
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
