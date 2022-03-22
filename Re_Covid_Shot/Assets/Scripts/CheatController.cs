using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatController : Singleton<CheatController>
{
    [SerializeField] GameObject CheatPanel;
    GameManager gameManager => GameManager.Instance;
    Player player => Player.Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvisibilityTrue();
        InvisbilityFalse();
        AllEnemyDead();
        SpawnRed();
        SpawnWhite();
    }

    private void MoveStage()
    {

    }

    private void PowerUP()
    {
        
    }

    public bool isInvisbilityCheat;
    private void InvisibilityTrue()
    {


        if (Input.GetKeyDown(KeyCode.I))
        {
            isInvisbilityCheat = true;
            player.isInvisibility = true;
        }
    }

    private void InvisbilityFalse()
    {
        if (Input.GetKeyDown(KeyCode.O) && isInvisbilityCheat)
        {
            player.isInvisibility = false;
        }
    }

    private void AllEnemyDead()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemyLogic = enemies[i].GetComponent<Enemy>();
                enemyLogic.Dead();
            }
        }
    }

    private void ChangeHP()
    {

    }

    private void ChangePain()
    {

    }

    private void SpawnRed()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnPoints.Instance.RedSpawn();
        }
    }

    private void SpawnWhite()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnPoints.Instance.WhiteSpawn();
        }
    }
}
