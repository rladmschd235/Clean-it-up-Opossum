using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //������ ����
    [SerializeField] private float initialMoveForce = 500f;                                 // ó�� �̵��� �� ������ ��
    [SerializeField] private float rotationSpeed = 360f;                                    // ȸ�� �ӵ� (��/��)
    [SerializeField] private float bounceForce = 300f;                                     // ���� ƨ�� �� ������ ��
    //���� ����
    [SerializeField, Range(1, 1000)] private float decelerationValue = 500f;      // ���� ���� (�ʴ� �ӵ� ���ҷ�)
    [SerializeField] private float stopThreshold = 1f;                                      // ���� ���� �ӵ�

    private int bounceCount = 0;                               // ƨ�� Ƚ��
    private Rigidbody rb;                                      // ������ٵ� ������Ʈ

    private void Awake()
    {
        GameScenes.globalPlayerMovement = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();        // ������ٵ� ������Ʈ ã��
        GameScenes.globalPlayerDrag.OnMoveStart += LaunchPlayer;
    }

    private void FixedUpdate()
    {
        if (GameScenes.globalPlayerDrag.isMoving)
        {
            ApplyDeceleration();
        }
    }

    private void ApplyDeceleration()
    {
        // ���� ������ 1~1000 ������ �����Ͽ� 0.9~0.999 ���̷� ��ȯ
        float decelerationFactor = Mathf.Lerp(0.8f, 0.99f, decelerationValue / 1000f);

        // ���� �ӵ��� ���� ������ ���� ���ҽ�Ŵ
        rb.velocity = new Vector3(rb.velocity.x * decelerationFactor, 0f, rb.velocity.z * decelerationFactor);

        Debug.Log($"���� �ӵ�: {rb.velocity.magnitude}");

        // �ӵ��� ���� ���� ������ �� �÷��̾ ����
        if (rb.velocity.magnitude < stopThreshold)
        {
            rb.velocity = Vector3.zero;
            GameScenes.globalPlayerDrag.isMoving = false;
            Debug.Log("�÷��̾ ������ϴ�.");
        }
    }

    public void LaunchPlayer(Vector3 direction, float power)
    {
        // ������ٵ� �ʱ� �̵� ���� ����
        Vector3 force = direction * power * initialMoveForce;
        Debug.Log($"����: {direction}, ��: {force}");
        rb.AddForce(force, ForceMode.Impulse);

        // ȸ�� ��ũ�� �߰�
        rb.AddTorque(transform.up * rotationSpeed * Mathf.Deg2Rad, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Wall")) return;
        var contactPoint = collision.GetContact(0);
        var collisionDirection = transform.position - contactPoint.point;
        Vector3 bounceForceVector = collisionDirection.normalized * bounceForce / (bounceCount + 1);
        rb.AddForce(bounceForceVector, ForceMode.Impulse);
        bounceCount++;
    }

    #region �׽�Ʈ��
    public Rigidbody GetRb() //�׽�Ʈ��
    {
        return rb;
    }

    public void SetRb(Rigidbody setRb)
    {
        rb.velocity = setRb.velocity;
    }
    #endregion
}