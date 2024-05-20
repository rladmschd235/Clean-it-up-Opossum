using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private StageDB stageDB;

    public int stageNumber; 

    public int level;
    public int chance;
    public int clearCount;

    public int trashCount; // 임시 변수

    private void OnEnable()
    {
        StageNumberLoad();
        StageNumberSave();
    }

    private void Update()
    {
        SetStage();

        if(trashCount == clearCount)
        {
            StageNumberUpdate();
        }
    }

    private void SetStage()
    {
        level = stageDB.StageDBEntities[stageNumber].level;
        chance = stageDB.StageDBEntities[stageNumber].level;
        clearCount = stageDB.StageDBEntities[stageNumber].clearCount;
    }

    private void StageNumberUpdate()
    {
        stageNumber++;
        StageNumberSave();

        // 다음 스테이지 활성화
        // 현재 스테이지 비활성화

        if(stageNumber == stageDB.StageDBEntities.Count)
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
}
