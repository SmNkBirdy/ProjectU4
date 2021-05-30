using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airStreamScript : MonoBehaviour
{
    [SerializeField] private Vector3 _airDirrection;
    [SerializeField] private float _airStrenght;

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<CharacterMovement>()._horizontalSpeed += new Vector3(_airDirrection.normalized.x * _airStrenght, 0, _airDirrection.normalized.z * _airStrenght) * Time.deltaTime;
        other.GetComponent<CharacterMovement>()._verticalSpeed += _airDirrection.normalized.y * _airStrenght * Time.deltaTime;
        other.GetComponent<PlayerMood>().becomeDizzy();
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<PlayerMood>().becomeNormal();
    }
}
