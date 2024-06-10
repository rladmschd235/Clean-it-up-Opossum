using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragUIManager : MonoBehaviour
{
    public GameObject joystick; //���̽�ƽ �ֻ��� ������Ʈ

    [SerializeField] private float maxDragDistance = 5f;
    [SerializeField] private TextMeshProUGUI DragCnt;
    
    private Image arrow;
    private Image[] joystickSet; //0��: ��� / 1��: ����
    private Vector3 leverStartPosition; // ������ �ʱ� ��ġ

    private void Awake()
    {
        GameScenes.globalDragUIManager = this;
    }

    void Start()
    {
        arrow.enabled = false;
        GameScenes.globalPlayerDrag.OnDragStart += ShowIndicator;
        GameScenes.globalPlayerDrag.OnDrag += UpdateIndicator;
        GameScenes.globalPlayerDrag.OnDragEnd += HideIndicator;
        joystickSet = joystick.GetComponentsInChildren<Image>(); // 0��: ��� / 1��: ����
        leverStartPosition = joystickSet[1].transform.position; // �ʱ� ���� ��ġ ����
    }

    private void ShowIndicator(Vector3 position)
    {
        Vector3 uiPosition = Camera.main.WorldToScreenPoint(position); // ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ
        joystick.SetActive(true);
        joystick.transform.position = uiPosition;
        arrow.enabled = true;
    }

    private void UpdateIndicator(Vector3 position)
    {
        Vector3 uiPosition = Camera.main.WorldToScreenPoint(position);
        joystickSet[1].transform.position = Vector3.ClampMagnitude(uiPosition - joystickSet[0].transform.position, maxDragDistance) + joystickSet[0].transform.position;
    }

    private void HideIndicator(Vector3 position)
    {
        joystickSet[1].transform.position = leverStartPosition; // ������ �ʱ� ��ġ�� ����
        joystick.SetActive(false);
        arrow.enabled = false;
        UpdateDragCnt();
    }

    private void UpdateDragCnt()
    {
        DragCnt.text = $"DragCnt: {GameScenes.globalPlayerDrag.dragCnt}";
    }

    void OnDestroy()
    {
        GameScenes.globalPlayerDrag.OnDragStart -= ShowIndicator;
        GameScenes.globalPlayerDrag.OnDrag -= UpdateIndicator;
        GameScenes.globalPlayerDrag.OnDragEnd -= HideIndicator;
    }

    public void SetArrow(Image setArrow)
    {
        arrow = setArrow;
    }
}