using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //움직임 변수
    [SerializeField] private float initialMoveForce = 500f;                                 // 처음 이동할 때 적용할 힘
    [SerializeField] private float rotationSpeed = 360f;                                    // 회전 속도 (도/초)
    [SerializeField] private float bounceForce = 300f;                                     // 벽에 튕길 때 적용할 힘
    //감속 변수
    [SerializeField, Range(1, 1000)] private float decelerationValue = 500f;      // 감속 비율 (초당 속도 감소량)
    [SerializeField] private float stopThreshold = 1f;                                      // 멈춤 기준 속도

    private int bounceCount = 0;                               // 튕긴 횟수
    private Rigidbody rb;                                      // 리지드바디 컴포넌트

    private void Awake()
    {
        GameScenes.globalPlayerMovement = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();        // 리지드바디 컴포넌트 찾기
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
        // 감속 비율을 1~1000 범위로 조정하여 0.9~0.999 사이로 변환
        float decelerationFactor = Mathf.Lerp(0.8f, 0.99f, decelerationValue / 1000f);

        // 현재 속도를 감속 비율에 따라 감소시킴
        rb.velocity = new Vector3(rb.velocity.x * decelerationFactor, 0f, rb.velocity.z * decelerationFactor);

        Debug.Log($"현재 속도: {rb.velocity.magnitude}");

        // 속도가 멈춤 기준 이하일 때 플레이어를 멈춤
        if (rb.velocity.magnitude < stopThreshold)
        {
            rb.velocity = Vector3.zero;
            GameScenes.globalPlayerDrag.isMoving = false;
            Debug.Log("플레이어가 멈췄습니다.");
        }
    }

    public void LaunchPlayer(Vector3 direction, float power)
    {
        // 리지드바디에 초기 이동 힘을 가함
        Vector3 force = direction * power * initialMoveForce;
        Debug.Log($"방향: {direction}, 힘: {force}");
        rb.AddForce(force, ForceMode.Impulse);

        // 회전 토크를 추가
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

    #region 테스트용
    public Rigidbody GetRb() //테스트용
    {
        return rb;
    }

    public void SetRb(Rigidbody setRb)
    {
        rb.velocity = setRb.velocity;
    }
    #endregion
}