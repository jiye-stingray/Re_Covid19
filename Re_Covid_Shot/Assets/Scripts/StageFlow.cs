using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFlow : Singleton<StageFlow>
{
    int stageCount = 1;
    GameManager gameManager => GameManager.Instance;

    public override void Awake()
    {
    }

    void Start()
    {
        StartStage(stageCount);
    }

    void Update()
    {
    }

    void StartStage(int stage)
    {
        if (stage == 1)
            GameManager.Instance.Init();
            
        string stageName = "stage" + stage.ToString();
        SpawnPoints.Instance.SpawnPoint(stageName);
    }

    public void EndStage()
    {
        StageBonusScoreCheck();
        if (stageCount >= 2)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            stageCount++;
            StartStage(stageCount);
        }
    }

    private void StageBonusScoreCheck()
    {
        gameManager.stageScore += gameManager.HP;
        gameManager.stageScore += GameManager.MaxPain - gameManager.Pain;
    }

    public void MoveStage(int stage)
    {
        SpawnPoints spawnPoints = SpawnPoints.Instance;
        spawnPoints.StopCoroutine(spawnPoints.SpawnCouroutine);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
        GameObject[] NPCs = GameObject.FindGameObjectsWithTag("NPC");
        for (int i = 0; i < NPCs.Length; i++)
        {
            Destroy(NPCs[i]);
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }

        StartStage(stage);

    }
}
