using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    private bool lookAtCamera;
    private DimensionsManager dm;
    void Start()
    {
        dm = GameObject.Find("GameManager").GetComponent<DimensionsManager>();
    }

    public void lookAt(Vector3 point)
    {
        if (!lookAtCamera)
        {
            gameObject.transform.LookAt(point);
        }
    }

    public void LookAtCamera(bool permission)
    {
        lookAtCamera = permission;
        if (permission)
        {
            gameObject.transform.LookAt(new Vector3(transform.position.x - dm.DimensionsDirection.x, transform.position.y, transform.position.z - dm.DimensionsDirection.y));
        }
    }
}
