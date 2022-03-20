using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    static SystemManager instance;

    public static SystemManager Instance
    {
        get
        {
            return instance;
        }
    
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null)
        {
            Debug.LogError("instance error");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    [SerializeField] GameManager gameManager;
    public GameManager GameManager
    {
        get
        {
            return gameManager;
        }
    }

    [SerializeField] Player player;
    public Player Player
    {
        get
        {
            return player;
        }
    }

    [SerializeField] SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints
    {
        get
        {
            return spawnPoints;
        }
    }

    [SerializeField] StageFlow stageFlow;
    public StageFlow StageFlow
    {
        get
        {
            return stageFlow;
        }
    }
}
