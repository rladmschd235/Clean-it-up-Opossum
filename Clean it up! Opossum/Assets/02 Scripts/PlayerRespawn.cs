using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3[] startPos;

    private void Awake()
    {
        GameScenes.globalPlayerRespawn = this;
    }

    private void Update()
    {
        DeathCheck();
    }

    private void DeathCheck()
    {
        if (GameScenes.globalPlayerDrag.dragCnt > GameScenes.globalStageManager.chance &&
            GameScenes.globalStageManager.clearCount > GameScenes.globalStageManager.trashCount)
        {
            GameScenes.globalTrashChecker.SetTrashCount();
            GameScenes.globalGameManager.GameOver();
        }
    }

    public void PosLoad(int stageNumber) // 저장 된 위치 불러오기
    {
        this.transform.position = startPos[stageNumber];
    }
}

