using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMood : MonoBehaviour
{
    public GameObject modelNormal;
    public GameObject modelAngry;
    public GameObject modelDizzy;
    public GameObject modelPleased;
    // Start is called before the first frame update
    public void becomeNormal()
    {
        modelNormal.SetActive(true);
        modelAngry.SetActive(false); ;
        modelDizzy.SetActive(false); ;
        modelPleased.SetActive(false); ;
    }

    public void becomeAngry()
    {
        modelNormal.SetActive(false);
        modelAngry.SetActive(true); ;
        modelDizzy.SetActive(false); ;
        modelPleased.SetActive(false); ;
    }

    public void becomeDizzy()
    {
        modelNormal.SetActive(false);
        modelAngry.SetActive(false); ;
        modelDizzy.SetActive(true); ;
        modelPleased.SetActive(false); ;
    }

    public void becomePleased()
    {
        modelNormal.SetActive(false);
        modelAngry.SetActive(false); ;
        modelDizzy.SetActive(false); ;
        modelPleased.SetActive(true); ;
    }

    public void setVisibility(bool boolian)
    {
        if (boolian)
        {
            modelNormal.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            modelAngry.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            modelDizzy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            modelPleased.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            modelNormal.transform.localScale = new Vector3(0, 0, 0);
            modelAngry.transform.localScale = new Vector3(0, 0, 0);
            modelDizzy.transform.localScale = new Vector3(0, 0, 0);
            modelPleased.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
