using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverUIController: MonoBehaviour
{
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
