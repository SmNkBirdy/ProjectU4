using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    public GameObject platform;
    public float delay = 1f;
    public float disTime = 2f;
    public float disStartTime = 0f;

    private void Update()
    {
        if (disStartTime + delay + disTime < Time.time && disStartTime != 0)
        {
            platform.SetActive(true);
        }
        else if (disStartTime + delay < Time.time && disStartTime != 0)
        {
            platform.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("start");
        disStartTime = Time.time;
    }
}
