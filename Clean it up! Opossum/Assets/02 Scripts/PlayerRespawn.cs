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

    private void PosSave() // 드래그 시 위치 저장
    {
        savePos = transform.position;
    }

    private void PosLoad() // 저장 된 위치 불러오기
    {
        transform.position = savePos;
    }
}
