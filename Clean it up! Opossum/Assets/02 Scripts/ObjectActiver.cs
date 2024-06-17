using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiver : MonoBehaviour
{
    private void Awake()
    {
        GameScenes.globalObjectActiver = this;
    }

    public void ObjectActiveOn()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
