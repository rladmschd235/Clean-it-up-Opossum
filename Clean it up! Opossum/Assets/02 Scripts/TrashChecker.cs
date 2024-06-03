using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashChecker : MonoBehaviour
{
    public int trashCount = 0;

    private void Awake()
    {
        GameScenes.globalTrashChecker = this;
    }

    public void SetTrashCount()
    {
        trashCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Trash"))
        {
            trashCount++;
            GameScenes.globalUIManager.UpdateSlider();
            GameScenes.globalSoundManager.PlaySFX("GetTrash");
            other.gameObject.SetActive(false);
        }
    }
}
