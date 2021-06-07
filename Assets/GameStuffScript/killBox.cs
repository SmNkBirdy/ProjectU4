using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBox : MonoBehaviour
{
    [SerializeField] private int _damage;
    private GameManager _gm;
    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Die");
            other.GetComponent<playerHealth>().Health -= _damage;
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = _gm.savePoint;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
