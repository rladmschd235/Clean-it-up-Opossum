using UnityEngine;
using System; // System ���ӽ����̽� �߰�

public class PlayerDrag : MonoBehaviour
{
    [SerializeField] private float maxDragDistance = 5.0f;  // �ִ� �巡�� �Ÿ�
    [SerializeField] private float minDragDistance = 0.0f;

    public event Action<Vector3> OnDragStart;  // �巡�� ���� �̺�Ʈ
    public event Action<Vector3> OnDrag;       // �巡�� �� �̺�Ʈ
    public event Action<Vector3> OnDragEnd;    // �巡�� �� �̺�Ʈ
    public int dragCnt = 0;

    private Vector3 dragStartPosition;
    private bool isDragging = false;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        GameScenes.globalPlayerDrag = this;
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    void Update()
    {
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
        OnDragStart?.Invoke(dragStartPosition); // �̺�Ʈ �߻�
    }

    private void Dragging()
    {
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        currentMousePosition.y = transform.position.y;
        Vector3 dragDirection = currentMousePosition - dragStartPosition;
        transform.rotation = Quaternion.LookRotation(-dragDirection); // �÷��̾ �ݴ� ������ �ٶ󺸵��� ȸ��
        OnDrag?.Invoke(currentMousePosition); // �̺�Ʈ �߻�
    }

    private void EndDrag()
    {
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        currentMousePosition.y = transform.position.y;
        Vector3 dragDirection = dragStartPosition - currentMousePosition;
        float dragDistance = Mathf.Clamp(dragDirection.magnitude, minDragDistance, maxDragDistance);
        isDragging = false;
        dragCnt++; // �巡��  ī��Ʈ
        OnDragEnd?.Invoke(currentMousePosition); // �̺�Ʈ �߻�
        playerMovement.LaunchPlayer(dragDirection, dragDistance); // �÷��̾� �̵�
    }
}