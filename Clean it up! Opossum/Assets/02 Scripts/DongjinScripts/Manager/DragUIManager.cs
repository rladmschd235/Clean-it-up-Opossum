using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragUIManager : MonoBehaviour
{
    public GameObject joystick; //조이스틱 최상위 오브젝트

    [SerializeField] private float maxDragDistance = 5f;
    [SerializeField] private TextMeshProUGUI DragCnt;
    
    private Image arrow;
    private Image[] joystickSet; //0번: 배경 / 1번: 레버
    private Vector3 leverStartPosition; // 레버의 초기 위치

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
        joystickSet = joystick.GetComponentsInChildren<Image>(); // 0번: 배경 / 1번: 레버
        leverStartPosition = joystickSet[1].transform.position; // 초기 레버 위치 저장
    }

    private void ShowIndicator(Vector3 position)
    {
        Vector3 uiPosition = Camera.main.WorldToScreenPoint(position); // 월드 좌표를 스크린 좌표로 변환
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
        joystickSet[1].transform.position = leverStartPosition; // 레버를 초기 위치로 복원
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