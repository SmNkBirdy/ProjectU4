using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionsManager : MonoBehaviour
{
    public Vector2 DimensionsDirection;
    public bool xDimension = true;
    public bool yDimestion = true;
    public bool zDimestion = true;

    public Vector3 getForward()
    {
        return new Vector3(DimensionsDirection.x, 0, DimensionsDirection.y);
    }
    public Vector3 getRight()
    {
        return new Vector3(DimensionsDirection.y, 0, -DimensionsDirection.x);
    }
}
