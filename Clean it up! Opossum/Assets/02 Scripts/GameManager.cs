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

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            GameStart();
        }
    }

    private void GameStart()
    {
        isGameStart = true;

        // ���� ȭ�� UI Ȱ��ȭ
        // ���� ȭ�� UI Ȱ��ȭ
        // ����� ȭ�� UI ��Ȱ��ȭ
    }

    private void GamePlay()
    {
        // ���� ȭ�� UI ��Ȱ��ȭ
        // ���� ȭ�� UI Ȱ��ȭ
        // ����� ȭ�� UI ��Ȱ��ȭ
    }

    private void GameOver()
    {
        isGameStart = false;

        // ���� ȭ�� UI ��Ȱ��ȭ
        // ���� ȭ�� UI ��Ȱ��ȭ 
        // ����� ȭ�� UI Ȱ��ȭ
    }

    private void GameClear()
    {
        // ���� ȭ�� UI ��Ȱ��ȭ
        // ���� ȭ�� UI ��Ȱ��ȭ 
        // ����� ȭ�� UI Ȱ��ȭ
    }
}
