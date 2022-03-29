using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnPoints : Singleton<SpawnPoints>
{
    [SerializeField] Transform[] spawnPoints;
    //0. Red
    //1. White
    [SerializeField] GameObject[] NPCs;
    [SerializeField] Transform[] redPostion;
    [SerializeField] Transform[] whitePostion;

    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] bosses;

    public bool showingBoss;
    public IEnumerator SpawnCouroutine;


    List<SpawnData> spawnList = new List<SpawnData>();
    void Update()
    {

        CheckRed();
        CheckWhite();
    }


    public void SpawnPoint(string stageName)
    {
        //코루틴
        SpawnCouroutine = SpawnEnemy();

        #region Parce
        spawnList.Clear();

        TextAsset textAsset = Resources.Load(stageName) as TextAsset;
        StringReader stringReader = new StringReader(textAsset.text);



        while (stringReader != null)
        {
            string line = stringReader.ReadLine();

            if (line == null)
                break;

            SpawnData spawnData = new SpawnData();

            spawnData.Type = line.Split(',')[0];
            spawnData.Pos   = int.Parse(line.Split(',')[1]);
            spawnData.Delay = float.Parse(line.Split(',')[2]);

            spawnList.Add(spawnData);

        }

        stringReader.Close();

        #endregion


        StartCoroutine(SpawnCouroutine);

    }

    GameObject ReturnEnemy(string type)
    {
        GameObject enemy = null;

        switch (type)
        {
            case "B":
                enemy = enemies[0];
                break;

            case "G":
                enemy = enemies[1];
                break;
            case "V":
                enemy = enemies[2];
                break;
            case "C":
                enemy = enemies[3];
                break;

            default:
                break;
        }

        return enemy;
    }


    public IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            GameObject enemy = ReturnEnemy(spawnList[i].Type);
            Transform tramsform = spawnPoints[spawnList[i].Pos];

            Instantiate(enemy, tramsform.position, tramsform.rotation);

            yield return new WaitForSeconds(spawnList[i].Delay);

        }

        yield return new WaitForSeconds(2f);
        BossManager.Instance.InstantiateBoss();
        
    }

    public float redTimer;
    void CheckRed()
    {
        if (showingBoss)
            return;

        redTimer += Time.deltaTime;
        if (redTimer >= 0.5f)    //등장 주기 
        {

            if (Random.Range(0, 10) == 0)     //등장 확률
            {
                RedSpawn();
            }
            redTimer = 0;
        }
    }

    public void RedSpawn()
    {
        Transform trans = redPostion[Random.Range(0, redPostion.Length)];
        Instantiate(NPCs[0], trans.position, trans.rotation);
    }

    float whiteTime;
    void CheckWhite()
    {
        if (showingBoss)
            return;

        whiteTime += Time.deltaTime;
        if (whiteTime >= 0.5f)    //등장 주기 
        {
            if (Random.Range(0, 10) == 0)     //등장 확률
            {
                WhiteSpawn();
            }
            whiteTime = 0;
        }
    }

    public void WhiteSpawn()
    {
        Transform trans = whitePostion[Random.Range(0, redPostion.Length)];

        Instantiate(NPCs[1], trans.position, trans.rotation);
    }

}
