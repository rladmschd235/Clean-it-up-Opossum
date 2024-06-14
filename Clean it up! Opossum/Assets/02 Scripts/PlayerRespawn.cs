using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform floor;

    private Vector3 startPos;

    private void Start()
    {
        floor = GameObject.FindWithTag("Area").transform;
    }

    private void Update()
    {
        DeathCheck();
    } 

    private void DeathCheck()
    {
        Vector3 floorPosition = floor.transform.position;
        Vector3 floorScale = floor.transform.localScale;

        // 바닥의 크기를 고려하여 x, z 범위를 계산합니다.
        float floorMinX = floorPosition.x - floorScale.x / 2;
        float floorMaxX = floorPosition.x + floorScale.x / 2;
        float floorMinZ = floorPosition.z - floorScale.z / 2;
        float floorMaxZ = floorPosition.z + floorScale.z / 2;

        //드래그 카운트 한계를 초과하면서 쓰레기 갯수를 다 채우지 못한 경우 혹은 맵밖으로 벗어난 경우
        if ((GameScenes.globalPlayerDrag.dragCnt == GameScenes.globalStageManager.chance && 
            GameScenes.globalStageManager.clearCount > GameScenes.globalStageManager.trashCount) || 
            (transform.position.x < floorMinX || transform.position.x  > floorMaxX || 
            transform.position.z < floorMinZ || transform.position.z > floorMaxZ))
        {
            GameScenes.globalGameManager.GameOver();
            PosLoad();
        }
    }

    public void PosSave()
    {
        startPos = transform.position;
    }

    public void PosLoad() // 저장 된 위치 불러오기
    {
        transform.position = startPos;
    }
}
