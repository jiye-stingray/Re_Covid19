using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheatController : Singleton<CheatController>
{
    [SerializeField] GameObject cheatPanel;
    GameManager gameManager => GameManager.Instance;
    BossManager bossManager => BossManager.Instance;
    StageFlow Stage => StageFlow.Instance;
    Player player => Player.Instance;

    [SerializeField] TMP_InputField stageInput;
    [SerializeField] TMP_InputField HPInput;
    [SerializeField] TMP_InputField painInput;
    [SerializeField] TMP_InputField powerInput;

    void Start()
    {
        cheatPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InvisibilityTrue();
        InvisbilityFalse();
        AllEnemyDeadCheak();
        SpawnRed();
        SpawnWhite();
        CheatPanelShow();
    }


    public bool isInvisbilityCheat;
    void InvisibilityTrue()
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
            isInvisbilityCheat = false;

        }
    }

    private void AllEnemyDeadCheak()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AllEnemyDead(true);
        }
    }
    
    /// <summary>
    /// ��� ������ ���̴� �Լ�
    /// </summary>
    /// <param name="isCheat">ġƮ�� ����� ��쿡�� ���� ����</param>
    public void AllEnemyDead(bool isCheat)
    {
        if (bossManager.mini1 != null && bossManager.mini2 != null)     //�̴� �������� �׾��� ���� ���� ���������� �Ѿ��
        {
            StageFlow.Instance.EndStage();
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemyLogic = enemies[i].GetComponent<Enemy>();
            if (!isCheat)    //ġƮ�� �������� �����ÿ��� ���� ������
            {
                if (enemies[i].TryGetComponent<Boss>(out var boss))
                    continue;
            }
            enemyLogic.Dead();
        }


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

    private void CheatPanelShow()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cheatPanel.SetActive(true);
            HPInput.text = "";
            painInput.text = "";
            stageInput.text = "";
            powerInput.text = "";
        }

    }

    /// <summary>
    /// �Է� ��ư�� ������ ��
    /// </summary>
    public void InputValue()
    {
        if (stageInput.text != "")
            MoveStageCheack(int.Parse(stageInput.text));
        if (HPInput.text != "")
            HPCheack(int.Parse(HPInput.text));
        if (painInput.text != "")
            painCheack(int.Parse(painInput.text));
        if (powerInput.text != "")
            PowerCheack(int.Parse(powerInput.text));
        cheatPanel.SetActive(false);
    }


    void MoveStageCheack(int stage)
    {
        if (stage == 1 || stage == 2)
            StageFlow.Instance.MoveStage(stage);
        else
            return;

    }

    void HPCheack(int HPAmount)
    {
        if (HPAmount > 100 || HPAmount < 0)
            return;
        GameManager.Instance.HP = HPAmount;
    }

    void painCheack(int painAmount)
    {
        if (painAmount > 100 || painAmount < 0)
            return;
        GameManager.Instance.Pain = painAmount;
    }

    void PowerCheack(int power)
    {
        if (power > 5 || power < 0)
            return;
        Player.Instance.BulletLevel = power;
    }

}
