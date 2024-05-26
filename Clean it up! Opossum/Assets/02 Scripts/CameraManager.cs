using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform
    public Vector3 offset; // 카메라와 플레이어 사이의 거리

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset; // 원하는 위치 계산
        transform.position = desiredPosition;
    }
}
