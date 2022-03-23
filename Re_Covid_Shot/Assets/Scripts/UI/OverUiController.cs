using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OverUIController: MonoBehaviour
{
    [SerializeField] TMP_Text enemyScoreText;
    [SerializeField] TMP_Text bonusScoreText;
    [SerializeField] TMP_Text totalScoreText;

    GameManager gameManager => GameManager.Instance;

    void Start()
    {
        enemyScoreText.text = gameManager.enemyScore.ToString() + " + ";
        bonusScoreText.text = gameManager.bonusScore.ToString() + " = ";
        totalScoreText.text = gameManager.totalScore.ToString();
    }

    void Update()
    {
        
    }

    public void RestartBtnClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameOverBtnClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
