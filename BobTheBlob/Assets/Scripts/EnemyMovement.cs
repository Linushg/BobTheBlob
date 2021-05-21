using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject nextTarget;

    [SerializeField] private float speed = 1f;

    [SerializeField] private List<GameObject> targetPoints;
    private int currenTargetPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (targetPoints.Count > 0)
        {
            nextTarget = targetPoints[0];
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (nextTarget != null)
        {
            MoveToPosition(nextTarget);
        }

    }

    private void MoveToPosition(GameObject moveToTarget)
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, moveToTarget.transform.position, speed);
        if (gameObject.transform.position == moveToTarget.transform.position)
        {
            ChangeTarget();
        }
    }

    private void ChangeTarget()
    {
        currenTargetPointIndex++;

        while (targetPoints[currenTargetPointIndex] == null)
        {
            currenTargetPointIndex++;
            if (currenTargetPointIndex >= targetPoints.Count)
            {
                currenTargetPointIndex = 0;
            }
        }

        nextTarget = targetPoints[currenTargetPointIndex];
    }
}
