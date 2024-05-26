using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform
    public Vector3 offset; // ī�޶�� �÷��̾� ������ �Ÿ�

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset; // ���ϴ� ��ġ ���
        transform.position = desiredPosition;
    }
}
