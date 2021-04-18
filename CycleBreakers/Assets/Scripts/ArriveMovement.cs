using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveMovement : MonoBehaviour, IAIMove
{
    private Vector2 moveAmount = Vector2.zero;

    [SerializeField] private float timeToTarget = 0f;
    [SerializeField] private float radius = 0f;

    public Vector2 getMovement(Transform target, float speed)
    {
        moveAmount = Vector2.zero;
        if (target == null)
        {
            return moveAmount; //zero
        }

        Vector2 vectorToTarget = target.position - this.transform.position;
        if (vectorToTarget.magnitude < radius)
        {
            return moveAmount; //still zero
        }

        moveAmount = vectorToTarget / timeToTarget;
        if (vectorToTarget.magnitude > speed)
        {
            moveAmount = vectorToTarget.normalized * speed;
        }
        return moveAmount;
    }
}
