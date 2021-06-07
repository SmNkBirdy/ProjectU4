using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pazzleElement : MonoBehaviour
{
    public Vector3 currentPoint;
    public float speed;
    void Awake()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        currentPoint = transform.position;
    }

    void Update()
    {

            if (Vector3.Distance(transform.position, currentPoint) > speed * Time.deltaTime)
            {
                transform.position += (currentPoint - transform.position).normalized * speed * Time.deltaTime;
            }
            else
            {
                transform.position = currentPoint;
            }
    }
}
