using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DolbitelScript : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public Vector3 currPoint;
    public float speed;
    public float delay;
    public float animtime;
    public float starttime;
    public float globDel;
    public AudioSource audS;
    private void Start()
    {
        starttime += globDel;
        currPoint = end.position;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, currPoint) < speed * Time.deltaTime)
        {
            transform.position = currPoint;
        }
        else
        {
            transform.position += (currPoint - transform.position).normalized * speed * Time.deltaTime;
        }
        if (starttime + animtime + delay < Time.time)
        {
            starttime = Time.time;
            audS.Stop();
            audS.Play();
            currPoint = start.position;
        }
        if (starttime + delay < Time.time)
        {
            audS.Stop();
            audS.Play();
            currPoint = end.position;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(2);
        if (collision.collider.name == "Player")
        {
            Debug.Log(1);
            collision.collider.GetComponent<CharacterController>().Move((currPoint - transform.position).normalized * speed * Time.deltaTime);
        }
    }
}
