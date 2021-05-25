using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject nextTarget;
    [SerializeField] private float speed = 3f;
    [SerializeField] private List<GameObject> targetPoints;
    private int currentTargetPointIndex;
    
    SpriteRenderer spriteRenderer;
    bool isFacingRight = false;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (targetPoints.Count > 0)
        {
            nextTarget = targetPoints[0];
        }
    }
    void FixedUpdate()
    {
        if (nextTarget != null)
        {
            MoveToPosition(nextTarget);
        }
    }
    private void MoveToPosition(GameObject moveToTarget)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveToTarget.transform.position, speed * Time.fixedDeltaTime);
        if (gameObject.transform.position == moveToTarget.transform.position)
        {
            ChangeTarget();
        }
    }
    private void ChangeTarget()
    {
        if(isFacingRight == false)
        {
            spriteRenderer.flipX = false;
            isFacingRight = true;
        } else if (isFacingRight == true)
        {
            spriteRenderer.flipX = true;
            isFacingRight = false;
        }
        currentTargetPointIndex++;
        if (currentTargetPointIndex >= targetPoints.Count)
        {
            currentTargetPointIndex = 0;
        }
        nextTarget = targetPoints[currentTargetPointIndex];
    }
}
