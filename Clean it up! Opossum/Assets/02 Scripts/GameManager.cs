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

        // 메인 화면 UI 활성화
        // 실행 화면 UI 활성화
        // 재시작 화면 UI 비활성화
    }

    private void GamePlay()
    {
        // 메인 화면 UI 비활성화
        // 실행 화면 UI 활성화
        // 재시작 화면 UI 비활성화
    }

    private void GameOver()
    {
        isGameStart = false;

        // 메인 화면 UI 비활성화
        // 실행 화면 UI 비활성화 
        // 재시작 화면 UI 활성화
    }

    private void GameClear()
    {
        // 메인 화면 UI 비활성화
        // 실행 화면 UI 비활성화 
        // 재시작 화면 UI 활성화
    }
}
