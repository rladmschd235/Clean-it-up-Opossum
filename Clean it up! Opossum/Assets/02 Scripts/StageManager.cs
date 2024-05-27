using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private StageDB stageDB;

    public int stageNumber; 

    public int level; // ���� 
    public int chance;  // ��ȸ
    public int clearCount; // Ŭ���� ī��Ʈ 

    public int trashCount; // �ӽ� ����

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

        //while (GameObject.FindWithTag("Trash") == true) ���� �ڵ�
        //{
        //    GameObject.FindWithTag("Trash").gameObject.SetActive(true);
        //}
    }

    public void StageNumberUpdate()
    {
        // ȹ���� ������ ���� �ʱ�ȭ
        GameScenes.globalTrashChecker.SetTrashCount();
        // ���� �������� Ȱ��ȭ & ���� �������� ��Ȱ��ȭ
        StageActivate(stageNumber);

        stageNumber++;
        StageNumberSave();

        if (stageNumber == stageDB.StageDBEntities.Count) // ������ ����������� ó�� ���������� �ʱ�ȭ
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

    public void StageActivate(int stageNumber)
    {
        transform.GetChild(stageNumber - 1).gameObject.SetActive(false); // ���� �������� ��Ȱ��ȭ
        transform.GetChild(stageNumber).gameObject.SetActive(true); // ���� �������� Ȱ��ȭ
    }
}
