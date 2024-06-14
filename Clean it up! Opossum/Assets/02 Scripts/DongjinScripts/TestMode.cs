using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMode : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GameScenes.globalGameManager.isGameStart = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
           var playerRb = GameScenes.globalPlayerMovement.GetRb();
            playerRb.velocity = Vector3.zero;
            GameScenes.globalPlayerMovement.SetRb(playerRb);
        }
        if(Input.GetKey(KeyCode.D))
        {
            Stage6Load();
        }
    }

    void Stage6Load()
    {
        PlayerPrefs.SetInt("StageNumber", 5);
        GameScenes.globalStageManager.StageActivate(5);
    }
}
