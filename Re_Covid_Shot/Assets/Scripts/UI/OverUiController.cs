using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OverUIController: MonoBehaviour
{
    [SerializeField] TMP_Text scoreCheckText;

    void Start()
    {
        
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
