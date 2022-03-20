using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFlow : MonoBehaviour
{
    int stageCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartStage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartStage()
    {
        string stageName = "stage" + stageCount.ToString();
        SystemManager.Instance.SpawnPoints.SpawnPoint(stageName);
    }


    public void EndStage()
    {
        Debug.Log("종료");
        if(stageCount >= 2)
        {
            Debug.Log("게임 클리어");
        }
        else
        {
            stageCount++;
            StartStage();
        }
    }

}
