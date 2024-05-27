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
    private List<GameObject> chanceImages = new List<GameObject>(); // ������ Chance ���� ����Ʈ

    private void Awake()
    {
        GameScenes.globalUIManager = this;
    }

    void Start()
    {
        //GameScenes.globalStageManager.StageSetting();

        //CreateChanceImages();

        // �����̴� �ʱⰪ ����
        //bgmSlider.value = GameScenes.globalSoundManager.audioSourceBgmPlayers.volume;
        //sfxSlider.value = GameScenes.globalSoundManager.audioSourceEffectsPlayers.volume;

        // �����̴� �� ���� �� �̺�Ʈ ���
        //bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        //sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Update()
    {
        //UpdateSlider();
        //UpdateChanceImages();
    }

    void HideAllUI() // ��� UI ����
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

    public void ShowInGameUI() // �ΰ��� UI �г� Ȱ��ȭ
    {
        HideAllUI();

        stageText.text = GameScenes.globalStageManager.stageNumber + " STAGE";

        inGameUI.SetActive(true);

        reButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);

        //CreateChanceImages(); // ���ο� �������� ���� �� chance �̹��� �ʱ�ȭ
    }

    public void ShowMainUI() // ���� ȭ�� UI �г� Ȱ��ȭ
    {
        HideAllUI();
        mainUI.SetActive(true);

        stageText.text = GameScenes.globalStageManager.stageNumber + " STAGE";

        reButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);

        Debug.Log(1);
    }

    public void ShowOverUI() // ���� ���� UI �г� Ȱ��ȭ
    {
        HideAllUI();
        overUI.SetActive(true);

        reButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }

    public void ShowClearUI() // ���� Ŭ���� UI �г� Ȱ��ȭ
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
        // ��ü ������ ����
        int totalItems = GameScenes.globalStageManager.clearCount;

        // ���� ȹ���� ������ ����
        int obtainedItems = GameScenes.globalStageManager.trashCount;

        // �����̴� �� ��� �� ����
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
        // ������ �̹������� ����
        foreach (GameObject image in chanceImages)
        {
            Destroy(image);
        }
        chanceImages.Clear();

        // ���ο� chance ���� ���� �̹��� ����
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

        // �����ִ� chance �̹��� ���� ����
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
