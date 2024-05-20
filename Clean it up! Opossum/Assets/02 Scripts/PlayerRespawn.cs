using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 savePos;

    private void Update()
    {
        DeathCheck();
    } 

    private void DeathCheck()
    {
        if (transform.position.y <= -2f)
        {
            Invoke("PosLoad", 1f);
        }
    }

    private void PosSave()
    {
        savePos = transform.position;
    }

    private void PosLoad()
    {
        transform.position = savePos;
    }
}
