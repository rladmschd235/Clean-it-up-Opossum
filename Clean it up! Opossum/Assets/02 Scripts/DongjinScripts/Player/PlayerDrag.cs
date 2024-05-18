using UnityEngine;
using System; // System 네임스페이스 추가

public class PlayerDrag : MonoBehaviour
{
    [SerializeField] private float maxDragDistance = 5.0f;  // 최대 드래그 거리
    [SerializeField] private float minDragDistance = 0.0f;  // 최소 드래그 거리
    [SerializeField] public Transform[] startTrms;          //시작 지점

    public event Action<Vector3> OnDragStart;  // 드래그 시작 이벤트
    public event Action<Vector3> OnDrag;       // 드래그 중 이벤트
    public event Action<Vector3> OnDragEnd;    // 드래그 끝 이벤트
    public int dragCnt = 0;                    //드래그 카운트
    public bool isMoving = false;              //움직이고 있는가?

    private Vector3 dragStartPosition;         //드래그 시작 위치
    private bool isDragging = false;           //드래그 중인가?
    private PlayerMovement playerMovement;     
    private float curDragDistance = 0;         //현재 드래그 된 정도

    private void Awake()
    {
        GameScenes.globalPlayerDrag = this;
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (isMoving) return;
        if (Input.GetMouseButtonDown(0))
        {
            StartDrag();
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Dragging();
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            EndDrag();
        }
    }

    private void StartDrag()
    {
        dragStartPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        dragStartPosition.y = transform.position.y;
        isDragging = true;
        OnDragStart?.Invoke(dragStartPosition); // 이벤트 발생
    }

    private void Dragging()
    {
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        currentMousePosition.y = transform.position.y;
        Vector3 dragDirection = currentMousePosition - dragStartPosition;
        transform.rotation = Quaternion.LookRotation(-dragDirection); // 플레이어가 반대 방향을 바라보도록 회전
        OnDrag?.Invoke(currentMousePosition); // 이벤트 발생
    }

    private void EndDrag()
    {
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        currentMousePosition.y = transform.position.y;
        Vector3 dragDirection = dragStartPosition - currentMousePosition;
        float dragDistance = Mathf.Clamp(dragDirection.magnitude, minDragDistance, maxDragDistance);
        curDragDistance = dragDistance;
        isDragging = false;
        dragCnt++; // 드래그  카운트
        OnDragEnd?.Invoke(currentMousePosition); // 이벤트 발생
        playerMovement.LaunchPlayer(dragDirection, dragDistance); // 플레이어 이동
        isMoving = true;
    }

    public float GetDragDistance()
    {
        return curDragDistance;
    }
}