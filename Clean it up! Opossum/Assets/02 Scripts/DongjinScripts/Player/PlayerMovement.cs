using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMultiplier = 10.0f;    // 이동에 적용할 힘의 배수
    [SerializeField] private float rotationSpeed = 10000f;      // 회전 토크의 크기 (더 큰 값으로 더 빠른 회전)
    private Rigidbody rb;                    // 리지드바디 컴포넌트

    void Start()
    {
        rb = GetComponent<Rigidbody>();      // 리지드바디 컴포넌트 찾기
    }

    public void LaunchPlayer(Vector3 direction, float distance)
    {
        // 리지드바디를 사용하여 플레이어에게 힘을 가함
        Vector3 force = direction * distance;
        rb.AddForce(force, ForceMode.Impulse);

        // 회전 토크를 추가
        rb.AddTorque(transform.up * rotationSpeed, ForceMode.Impulse);
    }
}