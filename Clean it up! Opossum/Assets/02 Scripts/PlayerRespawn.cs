using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 startPos;

    private void Update()
    {
        DeathCheck();
    } 

    private void DeathCheck()
    {
        if (GameScenes.globalPlayerDrag.dragCnt == GameScenes.globalStageManager.chance && 
            GameScenes.globalStageManager.clearCount > GameScenes.globalStageManager.trashCount)
        {
            GameScenes.globalGameManager.GameOver();
            PosLoad();
        }
    }

    public void PosSave()
    {
        startPos = transform.position;
    }

    public void PosLoad() // ���� �� ��ġ �ҷ�����
    {
        transform.position = startPos;
    }
}
