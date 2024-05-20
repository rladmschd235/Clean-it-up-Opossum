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

        // 메인 화면 UI 활성화
        // 실행 화면 UI 활성화
        // 재시작 화면 UI 비활성화
    }

    public void GamePlay()
    {
        isGameStart = true;

        // 메인 화면 UI 비활성화
        // 실행 화면 UI 활성화
        // 재시작 화면 UI 비활성화
    }

    public void GameOver()
    {
        isGameStart = false;

        // 메인 화면 UI 비활성화
        // 실행 화면 UI 비활성화 
        // 재시작 화면 UI 활성화
    }

    public void GameClear()
    {
        isGameStart = false;

        // 메인 화면 UI 비활성화
        // 실행 화면 UI 비활성화 
        // 재시작 화면 UI 활성화
    }
}
