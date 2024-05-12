using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMultiplier = 10.0f;    // �̵��� ������ ���� ���
    [SerializeField] private float rotationSpeed = 10000f;      // ȸ�� ��ũ�� ũ�� (�� ū ������ �� ���� ȸ��)
    private Rigidbody rb;                    // ������ٵ� ������Ʈ

    void Start()
    {
        rb = GetComponent<Rigidbody>();      // ������ٵ� ������Ʈ ã��
    }

    public void LaunchPlayer(Vector3 direction, float distance)
    {
        // ������ٵ� ����Ͽ� �÷��̾�� ���� ����
        Vector3 force = direction * distance;
        rb.AddForce(force, ForceMode.Impulse);

        // ȸ�� ��ũ�� �߰�
        rb.AddTorque(transform.up * rotationSpeed, ForceMode.Impulse);
    }
}