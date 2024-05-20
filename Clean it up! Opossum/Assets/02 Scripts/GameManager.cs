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

    public void GameStart()
    {
        isGameStart = false;

        // ���� ȭ�� UI Ȱ��ȭ
        // ���� ȭ�� UI Ȱ��ȭ
        // ����� ȭ�� UI ��Ȱ��ȭ
    }

    public void GamePlay()
    {
        isGameStart = true;

        // ���� ȭ�� UI ��Ȱ��ȭ
        // ���� ȭ�� UI Ȱ��ȭ
        // ����� ȭ�� UI ��Ȱ��ȭ
    }

    public void GameOver()
    {
        isGameStart = false;

        // ���� ȭ�� UI ��Ȱ��ȭ
        // ���� ȭ�� UI ��Ȱ��ȭ 
        // ����� ȭ�� UI Ȱ��ȭ
    }

    public void GameClear()
    {
        isGameStart = false;

        // ���� ȭ�� UI ��Ȱ��ȭ
        // ���� ȭ�� UI ��Ȱ��ȭ 
        // ����� ȭ�� UI Ȱ��ȭ
    }
}
