using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMultiplier = 10.0f;     // �̵��� ������ ���� ���
    [SerializeField] private float rotationSpeed = 10000f;      // ȸ�� ��ũ�� ũ�� (�� ū ������ �� ���� ȸ��)
    [SerializeField] private float bounceMultiplier = 100f;     //ƨ��� �ӵ� ����
    [SerializeField] private float decelerationSpeed = 0.99f;   // ���� ���(���� ���� ������ ������)
    private int bounceCnt = 0;                                  // ƨ�� Ƚ��
    private Rigidbody rb;                                       // ������ٵ� ������Ʈ

    void Start()
    {
        rb = GetComponent<Rigidbody>();      // ������ٵ� ������Ʈ ã��
    }

    private void Update()
    {
        if (GameScenes.globalPlayerDrag.isMoving)
        {
            rb.velocity = new Vector3(rb.velocity.x * decelerationSpeed, 0f, rb.velocity.z * decelerationSpeed);
        }
    }

    public void LaunchPlayer(Vector3 direction, float distance)
    {
        // ������ٵ� ����Ͽ� �÷��̾�� ���� ����
        Vector3 force = direction * distance;
        rb.AddForce(force, ForceMode.Impulse);

        // ȸ�� ��ũ�� �߰�
        rb.AddTorque(transform.up * rotationSpeed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    { 
        var cp = collision.GetContact(0);
        var dir = transform.position - cp.point;
        rb.AddForce((dir).normalized * (GameScenes.globalPlayerDrag.GetDragDistance() * bounceMultiplier / (bounceCnt + 1)));
        bounceCnt++;
    }
}