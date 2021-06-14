using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugCheck : MonoBehaviour
{
    public DataManager dm;
    private void Update()
    {
        gameObject.GetComponent<Text>().text = "checkpoint: " + dm.checkpoint;
    }
}
