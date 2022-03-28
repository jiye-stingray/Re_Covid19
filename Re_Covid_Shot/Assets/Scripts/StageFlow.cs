using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageFlow : Singleton<StageFlow>
{
    public int stageCount = 1;
    GameManager gameManager => GameManager.Instance;
    BossManager BossManager => BossManager.Instance;
    Player player => Player.Instance;

    [SerializeField] GameObject ImagePanel;
    [SerializeField] TMP_Text stageText;
     Animator anim;

    public override void Awake()
    {
        anim = ImagePanel.GetComponent<Animator>();
    }

    void Start()
    {
        StartStage(stageCount);
    }

    IEnumerator StartGame()
    {
        player.transform.position = new Vector2(0, -10);

        BoxCollider2D collider = player.GetComponent<BoxCollider2D>();

        collider.enabled = false;
        float timer = 0;
        for (; ; )
        {
            timer += Time.deltaTime;
            player.transform.Translate(Vector2.up * player.speed * Time.deltaTime);

            if (timer > 1f)
                break;
            yield return new WaitForEndOfFrame();
        }
        collider.enabled = true;


    }

    


    void StartStage(int stage)
    {
        if (stage == 1)
            StartCoroutine(StartGame());

        GameManager.Instance.Init();

        stageText.text = "Stage " + stage;
        anim.SetTrigger("isShow");


        string stageName = "stage" + stage.ToString();
        SpawnPoints.Instance.SpawnPoint(stageName);
    }

    public void EndStage()
    {
        InitBossManager();
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

    void InitBossManager()
    {
        BossManager.HP = 0;
        BossManager.boss = null;
        BossManager.mini1 = null;
        BossManager.mini2 = null;
        BossManager.HPBar.enabled = false;
    }

    public void MoveStage(int stage)
    {
        stageCount = stage;

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
