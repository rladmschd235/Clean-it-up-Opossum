using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private StageDB stageDB;

    public int stageNumber; 

    public int level; // 레벨 
    public int chance;  // 기회
    public int clearCount; // 클리어 카운트 

    public int trashCount; // 임시 변수

    private void OnEnable()
    {
        StageNumberLoad();
        StageNumberSave();
    }

    private void Awake()
    {
        GameScenes.globalStageManager = this;
    }

    private void Update()
    {
        if (GameScenes.globalTrashChecker.trashCount == clearCount)
        {
            GameScenes.globalGameManager.GameClear();
        }
    }

    public void StageSetting()
    {
        level = stageDB.StageDBEntities[stageNumber].level;
        chance = stageDB.StageDBEntities[stageNumber].level;
        clearCount = stageDB.StageDBEntities[stageNumber].clearCount;

        //while (GameObject.FindWithTag("Trash") == true) 문제 코드
        //{
        //    GameObject.FindWithTag("Trash").gameObject.SetActive(true);
        //}
    }

    public void StageNumberUpdate()
    {
        // 획득한 쓰레기 개수 초기화
        GameScenes.globalTrashChecker.SetTrashCount();
        // 다음 스테이지 활성화 & 현재 스테이지 비활성화
        StageActivate(stageNumber);

        stageNumber++;
        StageNumberSave();

        if (stageNumber == stageDB.StageDBEntities.Count) // 마지막 스테이지라면 처음 스테이지로 초기화
        {
            // 스테이지 번호 초기화
            stageNumber = 0;
        }
    }

    public void StageNumberSave()
    {
        PlayerPrefs.SetInt("StageNumber", stageNumber);
    }

    private void StageNumberLoad()
    {
        if(PlayerPrefs.HasKey("StageNumber"))
        {
            stageNumber = PlayerPrefs.GetInt("StageNumber");
        }
        else
        {
            stageNumber = 0;
        }
    }

    public void StageActivate(int stageNumber)
    {
        transform.GetChild(stageNumber - 1).gameObject.SetActive(false); // 이전 스테이지 비활성화
        transform.GetChild(stageNumber).gameObject.SetActive(true); // 다음 스테이지 활성화
    }
}
