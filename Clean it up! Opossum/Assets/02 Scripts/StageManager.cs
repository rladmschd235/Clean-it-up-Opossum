using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        // ���� �������� Ȱ��ȭ & ���� �������� ��Ȱ��ȭ
        StageOff(stageNumber);
        stageNumber++;
        StageActivate(stageNumber);

        // �������� ���� ���� �� ���� �������� ���� ����
        StageSetting();
        StageNumberSave();

        if (stageNumber == stageDB.StageDBEntities.Count) // ������ ����������� ó�� ���������� �ʱ�ȭ
        {
            // �������� ��ȣ �ʱ�ȭ
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
        transform.GetChild(stageNumber).gameObject.SetActive(true); // ���� �������� Ȱ��ȭ

        var stageObj = transform.GetChild(stageNumber).gameObject;
        GameScenes.globalDragUIManager.SetArrow(stageObj.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>());
    }

    public void StageOff(int stageNumber)
    {
        transform.GetChild(stageNumber).gameObject.SetActive(false); // ���� �������� ��Ȱ��ȭ
    }
}
