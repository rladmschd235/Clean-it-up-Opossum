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

    public int trashCount; // �ӽ� ����

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

        // ���� �������� Ȱ��ȭ
        // ���� �������� ��Ȱ��ȭ

        if(stageNumber == stageDB.StageDBEntities.Count)
        {
            // �������� ��ȣ �ʱ�ȭ
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
