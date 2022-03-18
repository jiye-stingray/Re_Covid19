using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    //0. Red
    //1. White
    [SerializeField] GameObject[] NPCs;
    [SerializeField] Transform[] redPostion;
    [SerializeField] Transform[] whitePostion;

    [SerializeField] GameObject[] enemies;


    List<SpawnData> spawnList = new List<SpawnData>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint("stage1");

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        CheckRed();
        CheckWhite();
    }

    void SpawnPoint(string stageName)
    {
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


    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            GameObject enemy = ReturnEnemy(spawnList[i].Type);
            Transform tramsform = spawnPoints[i];

            Instantiate(enemy, tramsform.position, tramsform.rotation);

            yield return new WaitForSeconds(spawnList[i].Delay);

        }

    }

    float redTimer;
    void CheckRed()
    {
        redTimer = Time.deltaTime;
        Debug.Log(redTimer);
        if (redTimer >= 0.1f)    //등장 주기 
        {

            RedSpawn();
            redTimer = 0;
            /*if (Random.Range(0, 1) == 0)     //등장 확률
            {
                Debug.Log("발사");
                
            }*/
        }
    }

    private void RedSpawn()
    {
        Transform trans = redPostion[Random.Range(0, redPostion.Length)];

        Instantiate(NPCs[0], trans.position, trans.rotation);
    }

    float whiteTime;
    void CheckWhite()
    {
        whiteTime = Time.deltaTime;
        if (whiteTime >= 3f)    //등장 주기 
        {
            if (Random.Range(0, 2) == 0)     //등장 확률
            {
                WhiteSpawn();
                whiteTime = 0;
            }
        }
    }

    private void WhiteSpawn()
    {
        Transform trans = redPostion[Random.Range(0, redPostion.Length)];

        Instantiate(NPCs[1], trans.position, trans.rotation);
    }

}
