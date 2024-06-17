using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        StageActivate(stageNumber);
        StageSetting();
    }   

    private void Update()
    {
        if (GameScenes.globalTrashChecker.trashCount == clearCount)
        {
            GameScenes.globalTrashChecker.SetTrashCount();
            GameScenes.globalGameManager.GameClear();
        }
    }

    public void StageSetting()
    {
        level = stageDB.StageDBEntities[stageNumber].level;
        chance = stageDB.StageDBEntities[stageNumber].chance;
        clearCount = stageDB.StageDBEntities[stageNumber].clearCount;
    }

    public void StageNextLoad()
    {
        // 다음 스테이지 활성화 & 현재 스테이지 비활성화
        StageOff(stageNumber);
        stageNumber++;
        StageActivate(stageNumber);

        // 스테이지 정보 세팅 및 현재 스테이지 정보 저장
        StageSetting();
        StageNumberSave();

        if (stageNumber == stageDB.StageDBEntities.Count) // 마지막 스테이지라면 처음 스테이지로 초기화
        {
            // 스테이지 번호 초기화
            stageNumber = 0;
        }

        GameScenes.globalGameManager.GamePlay();
    }

    public void StageReload()
    {
        GameScenes.globalGameManager.GamePlay();

        GameScenes.globalTrashChecker.SetTrashCount();
        GameScenes.globalPlayerRespawn.PosLoad(stageNumber);
        GameScenes.globalObjectActiver.ObjectActiveOn();
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
        transform.GetChild(stageNumber).gameObject.SetActive(true); // 다음 스테이지 활성화

        var stageObj = transform.GetChild(stageNumber).gameObject;
        GameScenes.globalDragUIManager.SetArrow(stageObj.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>());
    }

    public void StageOff(int stageNumber)
    {
        transform.GetChild(stageNumber).gameObject.SetActive(false); // 현재 스테이지 비활성화
    }
}
