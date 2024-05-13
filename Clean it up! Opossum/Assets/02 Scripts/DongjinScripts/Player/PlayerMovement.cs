using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMultiplier = 10.0f;     // 이동에 적용할 힘의 배수
    [SerializeField] private float rotationSpeed = 10000f;      // 회전 토크의 크기 (더 큰 값으로 더 빠른 회전)
    [SerializeField] private float bounceMultiplier = 100f;     //튕기는 속도 보강
    [SerializeField] private float decelerationSpeed = 0.99f;   // 감속 계수(낮을 수록 감속이 증가함)
    private int bounceCnt = 0;                                  // 튕김 횟수
    private Rigidbody rb;                                       // 리지드바디 컴포넌트

    void Start()
    {
        rb = GetComponent<Rigidbody>();      // 리지드바디 컴포넌트 찾기
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
        // 리지드바디를 사용하여 플레이어에게 힘을 가함
        Vector3 force = direction * distance;
        rb.AddForce(force, ForceMode.Impulse);

        // 회전 토크를 추가
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