using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScipt : MonoBehaviour
{
    public float Speed;
    public GameObject pointA;
    public GameObject pointB;
    private Vector3 Apos;
    private Vector3 Bpos;
    private Vector3 curPoint;
    void Start()
    {
        Apos = pointA.transform.position;
        Bpos = pointB.transform.position;
        curPoint = Apos;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(curPoint);
        if (Vector3.Distance(transform.position, curPoint) < Speed * Time.deltaTime * 2)
        {
            if (curPoint == Apos)
            {
                curPoint = Bpos;
            }
            else
            {
                curPoint = Apos;
            }
        }
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
}
