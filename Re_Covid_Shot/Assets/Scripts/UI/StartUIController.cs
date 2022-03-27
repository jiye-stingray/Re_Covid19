using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartUIController : MonoBehaviour
{

    [SerializeField] GameObject InformationPanel;

    // Start is called before the first frame update
    void Start()
    {
        InformationPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBtnClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowInformationPanelBtnClick()
    {
        InformationPanel.SetActive(true);
    }

    public void CloseInformationPanelBtnClick()
    {
        InformationPanel.SetActive(false);

    }
}
