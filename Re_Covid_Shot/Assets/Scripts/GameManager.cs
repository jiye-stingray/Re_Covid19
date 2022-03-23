using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public bool isGameOver = false;

    [SerializeField] private int hp;
    public int HP
    {
        get => hp;
        set
        {
            hp = value;
            if (hp <= 0 && !isGameOver)
            {
                GameOver();
            }
            else if (hp >= 100)
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

            if (pain >= MaxPain && !isGameOver)
            {
                GameOver();
            }
            else if (pain <= 0)
            {
                pain = 0;
            }
        }
    }
    public const int MaxPain = 100;

    public int totalScore = 0;
    public int bonusScore;
    public int enemyScore = 0;
    public int itemCountScore = 0;
    public int stageScore = 0;

    public List<Rank> rankingList = new List<Rank>();


    public void GameOver()
    {
        bonusScore = itemCountScore + stageScore;
        totalScore = enemyScore + itemCountScore + stageScore;
        isGameOver = true;
        SceneManager.LoadScene("GameOverScene");
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void Init()
    {
        isGameOver = false;
        HP = MaxHP;
        pain = (int)(MaxPain * 0.2f);
        totalScore = 0;
        enemyScore = 0;
        itemCountScore = 0;
        stageScore = 0;
    }
}
