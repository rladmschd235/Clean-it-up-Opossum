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

    void HideAllUI() // ��� UI ����
    {
        inGameUI.SetActive(false);
        mainUI.SetActive(false);
        overUI.SetActive(false);
        clearUI.SetActive(false);

        reButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }

    public void ShowInGameUI() // �ΰ��� UI �г� Ȱ��ȭ
    {
        HideAllUI();
        inGameUI.SetActive(true);

        reButton.gameObject.SetActive(false);
        settingButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
    }

    public void ShowMainUI() // ���� ȭ�� UI �г� Ȱ��ȭ
    {
        HideAllUI();
        mainUI.SetActive(true);

        reButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
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
        HideAllUI();
        clearUI.SetActive(true);

        reButton.gameObject.SetActive(true);
        settingButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
    }
}
