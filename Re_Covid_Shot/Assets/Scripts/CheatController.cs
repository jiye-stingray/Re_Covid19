using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatController : Singleton<CheatController>
{
    GameManager gameManager => GameManager.Instance;
    Player player => Player.Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvisibilityTrue();
        InvisbilityFalse();
    }

    private void MoveStage()
    {

    }

    private void PowerUP()
    {

    }

    public bool isInvisbilityCheat;
    private void InvisibilityTrue()
    {


        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("公利");
            isInvisbilityCheat = true;
            player.isInvisibility = true;
        }
    }

    private void InvisbilityFalse()
    {
        if (Input.GetKeyDown(KeyCode.O) && isInvisbilityCheat)
        {
            Debug.Log("公利 秒家");
            player.isInvisibility = false;
        }
    }

    private void AllEnemyDead()
    {

    }

    private void ChangeHP()
    {

    }

    private void ChangePain()
    {

    }

    private void SpawnRed()
    {

    }

    private void SpawnWhite()
    {

    }
}
