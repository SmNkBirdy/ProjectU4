using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turbineScript : MonoBehaviour
{
    private float startAnimTime;
    private float delayAnim = 0.05f;
    void Update()
    {
        if (Time.time > startAnimTime + delayAnim)
        {
            startAnimTime = Time.time;
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + 45, gameObject.transform.eulerAngles.z);
        }
    }
}
