using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private float increaseScale = 1.1f;
    [SerializeField] private float reduceScale = 0.8f;
    [SerializeField] private int increaseTime = 1;
    [SerializeField] private int reduceTime = 1;

    private bool isIdle = true;
    private bool isIdleStart = false;
    private bool isMovingStart = false;
    private Vector3 curScale;

    void Start()
    {
        curScale = transform.localScale;
    }
    
    void Update()
    {
        if (!GameScenes.globalGameManager.isGameStart) return;
        if(!GameScenes.globalPlayerDrag.isMoving)
        {
            isIdle = true;
        }
        else if(GameScenes.globalPlayerDrag.isMoving)
        {
            isIdle = false;
        }

        if (isIdle && !isIdleStart)
        {
            isMovingStart = false;
            StopCoroutine(MovingAnim());
            StartCoroutine(IdleAnim());
            isIdleStart = true;
        }
        else if(!isIdle && !isMovingStart)
        {
            isIdleStart = false;
            StopCoroutine(IdleAnim());
            StartCoroutine(MovingAnim());
            isMovingStart = true;
        }
    }

    IEnumerator MovingAnim()
    {
        while (true)
        {
            if (isIdle) 
            {
                transform.DOScale(curScale, 0);
                break; 
            }
            
            transform.DOScaleX(curScale.x * reduceScale, reduceTime);
            transform.DOScaleZ(curScale.z * reduceScale, reduceTime);
            yield return new WaitForSeconds(reduceTime);
        }
    }

    IEnumerator IdleAnim()
    {
        while (true)
        {
            if (!isIdle)
            {
                transform.DOScale(curScale, 0);
                break;
            }
            transform.DOScale(curScale * increaseScale, increaseTime);
            yield return new WaitForSeconds(increaseTime);
            transform.DOScale(curScale, increaseTime);
            yield return new WaitForSeconds(increaseTime);
        }
    }
}
