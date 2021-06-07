using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageDealer : MonoBehaviour
{
    public int damage;
    public bool lockX;
    public bool lockZ;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<playerHealth>().takeDamage(damage, new Vector3(lockX ? other.transform.position.x : transform.position.x, transform.position.y, lockZ ? other.transform.position.z : transform.position.z));
            Debug.Log("AY");
        }
    }
}
