using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : Singleton<BossManager>
{

    // 0. Boss
    // 1. BossPlus
    // 2. MiniBoss
    // 3. MiniBossPlus
    public GameObject[] bosses;
    int stage => StageFlow.Instance.stageCount;
    public Image HPBar;
    public float HP;
    float MaxHP;
    public bool isdivisible;

    public GameObject boss = null;
    public GameObject mini1 = null;
    public GameObject mini2 = null;

    void Start()
    {
        HPBar.enabled = false;
    }

    void Update()
    {
        if (HPBar.enabled == true)
        {
            if (boss != null)
                HP = boss.GetComponent<Boss>().HP;
            else if (mini1 != null && mini2 != null)
                HP = mini1.GetComponent<Boss>().HP + mini2.GetComponent<Boss>().HP;
            else if (mini1 != null && mini2 == null)
                HP = mini1.GetComponent<Boss>().HP + mini2.GetComponent<Boss>().HP;
            else if (mini1 == null && mini2 != null)
                HP = mini2.GetComponent<Boss>().HP + mini2.GetComponent<Boss>().HP;

            HPBar.fillAmount = (float)HP / MaxHP;
        }

    }

    public void InstantiateBoss()
    {
        HPBar.enabled = true;
        isdivisible = true;
        boss = Instantiate(bosses[stage - 1]);
        MaxHP = boss.GetComponent<Boss>().MaxHP;

    }

    public void InstantiateMiniBoss()
    {
        HPBar.enabled = true;

        mini1 = Instantiate(bosses[stage + 1]);
        mini2 = Instantiate(bosses[stage + 1]);

        MoveMiniBoss();

        MaxHP = mini1.GetComponent<Boss>().MaxHP + mini2.GetComponent<Boss>().MaxHP;
    }

    void MoveMiniBoss()
    {
        Boss logic1 = mini1.GetComponent<Boss>();
        logic1.moveVec = Vector2.right;
        Boss logic2 = mini2.GetComponent<Boss>();
        logic2.moveVec = Vector2.left;
    }


}
