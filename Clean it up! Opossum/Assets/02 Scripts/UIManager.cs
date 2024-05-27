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
    public GameObject settingUI;

    public Button reButton;
    public Button settingButton;
    public Button pauseButton;
    public Slider scoreSlider;

    public TextMeshProUGUI stageText;

    public GameObject chanceImagePrefab;
    public Transform chanceImageContainer;
    private List<GameObject> chanceImages = new List<GameObject>(); // 생성된 Chance 관리 리스트

    private void Awake()
    {
        GameScenes.globalUIManager = this;
    }

    void Start()
    {
        //GameScenes.globalStageManager.StageSetting();

        //CreateChanceImages();

        // 슬라이더 초기값 설정
        //bgmSlider.value = GameScenes.globalSoundManager.audioSourceBgmPlayers.volume;
        //sfxSlider.value = GameScenes.globalSoundManager.audioSourceEffectsPlayers.volume;

        // 슬라이더 값 변경 시 이벤트 등록
        //bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        //sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Update()
    {
        //UpdateSlider();
        //UpdateChanceImages();
    }

    void HideAllUI() // 모든 UI 숨김
    {
        inGameUI.SetActive(false);
        mainUI.SetActive(false);
        overUI.SetActive(false);
        clearUI.SetActive(false);
        pauseUI.SetActive(false);
        settingUI.SetActive(false);

        reButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }

    public void ShowInGameUI() // 인게임 UI 패널 활성화
    {
        HideAllUI();

        stageText.text = GameScenes.globalStageManager.stageNumber + " STAGE";

        inGameUI.SetActive(true);

        reButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);

        //CreateChanceImages(); // 새로운 스테이지 시작 시 chance 이미지 초기화
    }

    public void ShowMainUI() // 메인 화면 UI 패널 활성화
    {
        HideAllUI();
        mainUI.SetActive(true);

        stageText.text = GameScenes.globalStageManager.stageNumber + " STAGE";

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
        GameScenes.globalStageManager.StageSetting();
        GameScenes.globalStageManager.StageNumberUpdate();

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

    public void OnClickSettingReButton()
    {
        settingUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickPauseButton()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnClickSettingButton()
    {
        settingUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void CreateChanceImages()
    {
        // 기존의 이미지들을 삭제
        foreach (GameObject image in chanceImages)
        {
            Destroy(image);
        }
        chanceImages.Clear();

        // 새로운 chance 값에 따라 이미지 생성
        int chanceCount = GameScenes.globalStageManager.chance;
        for (int i = 0; i < chanceCount; i++)
        {
            GameObject newImage = Instantiate(chanceImagePrefab, chanceImageContainer);
            chanceImages.Add(newImage);
        }
    }

    private void UpdateChanceImages()
    {
        int remainingChances = GameScenes.globalStageManager.chance;

        // 남아있는 chance 이미지 갯수 조정
        for (int i = 0; i < chanceImages.Count; i++)
        {
            if (i < remainingChances)
            {
                chanceImages[i].SetActive(true);
            }
            else
            {
                chanceImages[i].SetActive(false);
            }
        }
    }
}
