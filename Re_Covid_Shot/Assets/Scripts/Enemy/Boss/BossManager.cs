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
    public float MaxHP;
    public bool isLastMiniBoss = false;        //분열된 보스에서 마지막 보스만 남았을 때 => 마지막 보스를 죽이면 다음 스테이지(또는, 게임 끝)

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
            ShowHPBarCheck();

            HPBar.fillAmount = (float)HP / MaxHP;
        }

    }

    /// <summary>
    /// 보스 생성
    /// </summary>
    public void InstantiateBoss()
    {
        HPBar.enabled = true;
        boss = Instantiate(bosses[stage - 1]);
        MaxHP = boss.GetComponent<Boss>().MaxHP;

    }

    /// <summary>
    /// 미니보스 생성
    /// </summary>
    public void InstantiateMiniBoss()
    {
        Debug.Log("fdsf");
        HPBar.enabled = true;
        isLastMiniBoss = false;
        mini1 = Instantiate(bosses[stage + 1]);
        mini2 = Instantiate(bosses[stage + 1]);

        MoveMiniBoss();

        MaxHP = mini1.GetComponent<Boss>().MaxHP + mini2.GetComponent<Boss>().MaxHP;
    }

    /// <summary>
    /// 등장한 미니보스가 양옆으로 이동
    /// </summary>
    void MoveMiniBoss()
    {
        Boss logic1 = mini1.GetComponent<Boss>();
        logic1.moveVec = Vector2.right;
        Boss logic2 = mini2.GetComponent<Boss>();
        logic2.moveVec = Vector2.left;
    }

    void ShowHPBarCheck()
    {

        if (boss != null)
        {
            HP = boss.GetComponent<Boss>().HP;
        }
        else if (mini1 != null && mini2 != null)
        {
            HP = mini1.GetComponent<Boss>().HP + mini2.GetComponent<Boss>().HP;
        }
        else if (mini1 != null && mini2 == null)
        {
            HP = mini1.GetComponent<Boss>().HP;
        }
        else if (mini1 == null && mini2 != null)
        {
            HP =mini2.GetComponent<Boss>().HP;
        }
    }
}
