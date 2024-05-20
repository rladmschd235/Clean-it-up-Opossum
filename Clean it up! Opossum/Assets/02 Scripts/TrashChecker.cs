using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashChecker : MonoBehaviour
{
    public int trashCount = 0;

    private void Awake()
    {
        // �۷ι��� �����ϱ�
    }

    private void Update()
    {
        
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
            Destroy(other.gameObject);
        }
    }
}
