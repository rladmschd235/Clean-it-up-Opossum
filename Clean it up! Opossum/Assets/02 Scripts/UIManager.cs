using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject mainUI;
    public GameObject overUI;
    public GameObject clearUI;
    public GameObject pauseUI;

    public Button reButton;
    public Button settingButton;
    public Button pauseButton;
    public Slider scoreSlider;

    public TextMeshProUGUI stageText;

    void Start()
    {
        ShowMainUI();
    }

    private void Update()
    {
        //UpdateSlider();
    }

    void HideAllUI() // 모든 UI 숨김
    {
        inGameUI.SetActive(false);
        mainUI.SetActive(false);
        overUI.SetActive(false);
        clearUI.SetActive(false);
        pauseUI.SetActive(false);

        reButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }

    public void ShowInGameUI() // 인게임 UI 패널 활성화
    {
        //GameScenes.globalStageManager.StageSetting();

        HideAllUI();

        //stageText.text = GameScenes.globalStageManager.stageNumber + " STAGE";

        inGameUI.SetActive(true);

        reButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
    }

    public void ShowMainUI() // 메인 화면 UI 패널 활성화
    {
        HideAllUI();
        mainUI.SetActive(true);

        //stageText.text = GameScenes.globalStageManager.stageNumber + " STAGE";

        reButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);

        Debug.Log(1);
    }

    public void ShowOverUI() // 게임 오버 UI 패널 활성화
    {
        HideAllUI();
        overUI.SetActive(true);

        reButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }
    public void ShowClearUI() // 게임 클리어 UI 패널 활성화
    {
        //GameScenes.globalStageManager.StageSetting();
        //GameScenes.globalStageManager.StageNumberUpdate();

        HideAllUI();
        clearUI.SetActive(true);

        reButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }

    public void UpdateSlider()
    {
        // 전체 아이템 갯수
        int totalItems = GameScenes.globalStageManager.clearCount;

        // 현재 획득한 아이템 갯수
        int obtainedItems = GameScenes.globalStageManager.trashCount;

        // 슬라이더 값 계산 및 설정
        float sliderValue = (float)obtainedItems / (float)totalItems;
        scoreSlider.value = sliderValue;
    }

    public void OnClickPauseReButton()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickPauseButton()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("눌럿다");
    }
}
