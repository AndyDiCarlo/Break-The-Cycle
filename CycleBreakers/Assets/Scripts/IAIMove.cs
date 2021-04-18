using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAIMove
{
    Vector2 getMovement(Transform transform, float speed);
}
