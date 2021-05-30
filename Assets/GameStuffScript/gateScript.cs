using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateScript : MonoBehaviour
{
    public GameObject door;
    public signalTaker st;
    // Start is called before the first frame update
    void Start()
    {
        st = gameObject.GetComponent<signalTaker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (st.powered == true)
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }
}
