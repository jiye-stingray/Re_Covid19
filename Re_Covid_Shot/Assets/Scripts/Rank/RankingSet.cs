using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingSet : MonoBehaviour
{
    [SerializeField] TMP_Text[] names;
    [SerializeField] TMP_Text[] scores;

    int score;
    string userName;

    List<Rank> rankingList = new List<Rank>();

    // Start is called before the first frame update
    void Start()
    {
        score = SystemManager.Instance.GameManager.score;

        RankingSeting("jiye", 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RankingSeting(string name, int score)
    {
        Rank rank = new Rank();

        rank.name = name;
        rank.score = score;

        rankingList.Add(rank);

        rankingList.Sort((rank1,rank2) => rank1.score.CompareTo(rank2.score));

        if (rankingList.Count >= 6)
            rankingList.RemoveAt(5);

        ShowRanking();

    }

    void ShowRanking()
    {
        for (int i = 0; i < rankingList.Count; i++)
        {
            names[i].text = rankingList[i].name;
            scores[i].text = rankingList[i].score.ToString();
        }
    }

}
