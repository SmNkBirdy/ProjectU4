using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    private signalGiver sg;
    // Start is called before the first frame update
    void Start()
    {
        sg = gameObject.GetComponent<signalGiver>();
    }

    private void OnTriggerStay(Collider other)
    {
        sg.on();
    }

    private void OnTriggerExit(Collider other)
    {
        sg.off();
    }
}
