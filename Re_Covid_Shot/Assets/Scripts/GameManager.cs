using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool isGameOver = false;

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
            else if(pain <= 0)
            {
                pain = 0;
            }
        }
    }
    public const int MaxPain = 100;

    public int itemCount;

    public int score;

    void GameOver()
    {
        Debug.Log("게임 끝");
        isGameOver = true;
        //게임 씬 끝
        SceneManager.LoadScene("GameOverScene");
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        //임시
        /*score = 20;
        HP = 0;*/

        pain = (int)(MaxPain * 0.2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
