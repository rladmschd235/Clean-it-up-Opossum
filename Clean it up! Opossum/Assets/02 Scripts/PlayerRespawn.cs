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

        // �ٴ��� ũ�⸦ ����Ͽ� x, z ������ ����մϴ�.
        float floorMinX = floorPosition.x - floorScale.x / 2;
        float floorMaxX = floorPosition.x + floorScale.x / 2;
        float floorMinZ = floorPosition.z - floorScale.z / 2;
        float floorMaxZ = floorPosition.z + floorScale.z / 2;

        //�巡�� ī��Ʈ �Ѱ踦 �ʰ��ϸ鼭 ������ ������ �� ä���� ���� ��� Ȥ�� �ʹ����� ��� ���
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

    public void PosLoad() // ���� �� ��ġ �ҷ�����
    {
        transform.position = startPos;
    }
}
