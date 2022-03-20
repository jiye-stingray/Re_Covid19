using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingSet : MonoBehaviour
{
    [SerializeField] TMP_Text[] names;
    [SerializeField] TMP_Text[] scores;

    [SerializeField] GameObject InputPanel;
    [SerializeField] TMP_InputField input;

    int score;
    string ID;

    List<Rank> rankingList = new List<Rank>();

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        InputPanel.SetActive(false);
        //score = SystemManager.Instance.GameManager.score;
        CheckScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckScore()
    {
        if (rankingList.Count < 5 || score >= rankingList[4].score)
        {
            InputID();

        }
    }

    private void InputID()
    {
        InputPanel.SetActive(true);
        
    }

    /// <summary>
    /// 아이디 입력 받는 버튼
    /// </summary>
    public void InputBtnClick()
    {
        ID = input.text;
        InputPanel.SetActive(false);
        RankingSeting(ID, score);
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
