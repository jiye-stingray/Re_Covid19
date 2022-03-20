using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFlow : Singleton<StageFlow>
{
    int stageCount = 1;

    public override void Awake()
    {
    }

    void Start()
    {
        StartStage();
    }

    void Update()
    {
    }

    void StartStage()
    {
        string stageName = "stage" + stageCount.ToString();
        //SystemManager.Instance.SpawnPoints.SpawnPoint(stageName);
    }


    public void EndStage()
    {
        Debug.Log("Á¾·á");
        if(stageCount >= 2)
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            stageCount++;
            StartStage();
        }
    }

}
