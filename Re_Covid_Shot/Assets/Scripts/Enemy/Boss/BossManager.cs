using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : Singleton<BossManager>
{

    // 0. Boss
    // 1. BossPlus
    // 2. MiniBoss
    public GameObject[] bosses;
    int stage => StageFlow.Instance.stageCount;
    public Image HPBar;
    float HP;
    float MaxHP;

    GameObject boss = null;
    GameObject mini1 = null;
    GameObject mini2 = null;

    void Start()
    {
        HPBar.enabled = false;
    }

    void Update()
    {
        if (boss != null)
        {
            HP = boss.GetComponent<Boss>().HP;
            HPBar.fillAmount = (float)HP / MaxHP;
        }
    }

    public void InstantiateBoss()
    {
        HPBar.enabled = true;
        boss = Instantiate(bosses[stage - 1]);
        MaxHP = boss.GetComponent<Boss>().MaxHP;

    }

    public void InstantiateMiniBoss()
    {
        mini1 = Instantiate(bosses[2]);
        mini2 = Instantiate(bosses[2]);

        MoveMiniBoss();

        HP = mini1.GetComponent<Boss>().HP + mini2.GetComponent<Boss>().HP;
        MaxHP = mini1.GetComponent<Boss>().MaxHP + mini2.GetComponent<Boss>().MaxHP;
    }

    void MoveMiniBoss()
    {
        float timer = 0f;
        Boss logic1 = mini1.GetComponent<Boss>();
        logic1.moveVec = Vector2.right;
        Boss logic2 = mini2.GetComponent<Boss>();
        logic2.moveVec = Vector2.left;


    }

}
