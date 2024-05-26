using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 savePos;

    private void Update()
    {
        DeathCheck();
    } 

    private void DeathCheck()
    {
        if (transform.position.y <= -2f)
        {
            Invoke("PosLoad", 1f);
        }
    }

    private void PosSave() // �巡�� �� ��ġ ����
    {
        savePos = transform.position;
    }

    private void PosLoad() // ���� �� ��ġ �ҷ�����
    {
        transform.position = savePos;
    }
}
