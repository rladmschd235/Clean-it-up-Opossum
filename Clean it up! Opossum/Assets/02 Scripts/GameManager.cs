using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStart = false;

    private void Awake()
    {
        GameScenes.globalGameManager = this;
    }

    private void Start()
    {
        GameStart();
    }

    public void GameStart()
    {
        isGameStart = false;

        // ���� ȭ�� UI Ȱ��ȭ
        // ���� ȭ�� UI Ȱ��ȭ
        // ����� ȭ�� UI ��Ȱ��ȭ
        GameScenes.globalUIManager.ShowMainUI();
    }

    public void GamePlay()
    {
        isGameStart = true;

        // ���� ȭ�� UI ��Ȱ��ȭ
        // ���� ȭ�� UI Ȱ��ȭ
        // ����� ȭ�� UI ��Ȱ��ȭ
        GameScenes.globalUIManager.ShowInGameUI();
    }

    public void GameOver()
    {
        isGameStart = false;

        // ���� ȭ�� UI ��Ȱ��ȭ
        // ���� ȭ�� UI ��Ȱ��ȭ 
        // ����� ȭ�� UI Ȱ��ȭ
        GameScenes.globalUIManager.ShowOverUI();
    }

    public void GameClear()
    {
        isGameStart = false;

        // ���� ȭ�� UI ��Ȱ��ȭ
        // ���� ȭ�� UI ��Ȱ��ȭ 
        // ����� ȭ�� UI Ȱ��ȭ
        GameScenes.globalUIManager.ShowClearUI();
    }
}
