using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int HP;
    public const int MaxHP = 100;
    public int pain;
    public const int MaxPain = 100;

    bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        pain = (int)(MaxPain * 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((HP <= 0 || pain == MaxPain) && !isGameOver)
        {
            //°ÔÀÓ ³¡
        }
    }
}
