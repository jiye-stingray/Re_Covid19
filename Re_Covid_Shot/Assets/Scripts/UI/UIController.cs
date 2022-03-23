using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text HPText;
    [SerializeField] TMP_Text painText;

    [SerializeField] Image HPImg;
    [SerializeField] Image painImg;

    [SerializeField] TMP_Text scoreText;

    GameManager gameManager => GameManager.Instance;

    void Start()
    {
    }

    void Update()
    {
        scoreText.text = "score: " + gameManager.enemyScore.ToString();

        HPText.text = gameManager.HP.ToString();
        painText.text = gameManager.Pain.ToString();

        HPImg.fillAmount = (float)gameManager.HP / GameManager.MaxHP;
        painImg.fillAmount = (float)gameManager.Pain / GameManager.MaxPain;
    }
}
