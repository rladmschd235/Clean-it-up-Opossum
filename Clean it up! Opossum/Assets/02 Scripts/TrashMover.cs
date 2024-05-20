using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMover : MonoBehaviour
{
    private float rotationTime;
    private float moveTime;

    public float rotationSpeed = 2f;
    public float moveSpeed = 2f;

    private void Start()
    {
        StartCoroutine(RoundRotate());
        StartCoroutine(VerticalMove());
    }

    void Update()
    {
        rotationTime += Time.deltaTime * rotationSpeed;
        moveTime += Time.deltaTime * moveSpeed;
    }

    IEnumerator RoundRotate()
    {
        while(true)
        {
            transform.rotation = Quaternion.Euler(0, rotationTime, 0);

            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator VerticalMove()
    {
        while(true)
        {
            float movePos = (Mathf.Sin(moveTime) + 1) * 0.5f;

            transform.position = new Vector3(transform.position.x, movePos, transform.position.z);

            yield return new WaitForSeconds(0.05f);
        }
    }
}
