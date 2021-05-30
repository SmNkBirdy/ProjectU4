using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signalGiver : MonoBehaviour
{
    public signalTaker st;

    public void on()
    {
        st.powered = true;
    }

    public void off()
    {
        st.powered = false;
    }
}
