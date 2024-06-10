using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform player; // �÷��̾��� Transform
    public Vector3 offset; // ī�޶�� �÷��̾� ������ �Ÿ�

    private void Update()
    {
        player = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset; // ���ϴ� ��ġ ���
        transform.position = desiredPosition;
    }
}
