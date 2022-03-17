using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;

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


    IEnumerator SpawnNPC()
    {
        for (; ; )
        {

        }
    }
}
