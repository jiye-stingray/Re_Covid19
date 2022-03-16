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
}
