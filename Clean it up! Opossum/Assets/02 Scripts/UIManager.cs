using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject mainUI;
    public GameObject overUI;
    public GameObject clearUI;

    public Button reButton;
    public Button settingButton;
    public Button pauseButton;

    void Start()
    {
        HideAllUI();

        ShowMainUI();
    }

    void HideAllUI() // 모든 UI 숨김
    {
        inGameUI.SetActive(false);
        mainUI.SetActive(false);
        overUI.SetActive(false);
        clearUI.SetActive(false);

        reButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }

    public void ShowInGameUI() // 인게임 UI 패널 활성화
    {
        HideAllUI();
        inGameUI.SetActive(true);

        reButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
    }

    public void ShowMainUI() // 메인 화면 UI 패널 활성화
    {
        HideAllUI();
        mainUI.SetActive(true);

        reButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
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
        HideAllUI();
        clearUI.SetActive(true);

        reButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }
}
