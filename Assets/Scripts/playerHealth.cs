using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class playerHealth : MonoBehaviour
{
    public int Health;
    private float daamageTakeTime;
    [SerializeField] private float afterDamageImuneTime;
    [SerializeField] private float damageThrowTime;
    [SerializeField] private float throwSpeed;
    private PlayerMood pm;
    private CharacterController controller;
    private CharacterMovement cm;
    private Vector3 horizontalDir;
    private AudioSource auds;

    private void Start()
    {
        auds = GameObject.Find("takeDamage").GetComponent<AudioSource>();
        pm = gameObject.GetComponent<PlayerMood>();
        controller = gameObject.GetComponent<CharacterController>();
        cm = gameObject.GetComponent<CharacterMovement>();
    }
    void Update()
    {
        if (Health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (daamageTakeTime + damageThrowTime > Time.time && daamageTakeTime != 0)
        {

            controller.Move(horizontalDir * throwSpeed * Time.deltaTime);
            if (daamageTakeTime + damageThrowTime - damageThrowTime/4 > Time.time)
            {
                pm.becomeAngry();
            }
            else
            {
                pm.becomeNormal();
            }

            if (daamageTakeTime + damageThrowTime - damageThrowTime / 10 * 9 > Time.time)
            {
                pm.setVisibility(false);
            }
            else if (daamageTakeTime + damageThrowTime - damageThrowTime / 10 * 8 > Time.time)
            {
                pm.setVisibility(true);
            }
            else if (daamageTakeTime + damageThrowTime - damageThrowTime / 10 * 7 > Time.time)
            {
                pm.setVisibility(false);
            }
            else if (daamageTakeTime + damageThrowTime - damageThrowTime / 10 * 6 > Time.time)
            {
                pm.setVisibility(true);
            }
            else if (daamageTakeTime + damageThrowTime - damageThrowTime / 10 * 5 > Time.time)
            {
                pm.setVisibility(false);
            }
            else if (daamageTakeTime + damageThrowTime - damageThrowTime / 10 * 4 > Time.time)
            {
                pm.setVisibility(true);
            }
            else if (daamageTakeTime + damageThrowTime - damageThrowTime / 10 * 3 > Time.time)
            {
                pm.setVisibility(false);
            }
            else if (daamageTakeTime + damageThrowTime - damageThrowTime / 10 * 2 > Time.time)
            {
                pm.setVisibility(true);
            }
            else if (daamageTakeTime + damageThrowTime - damageThrowTime / 10 * 1 > Time.time)
            {
                pm.setVisibility(false);
            }
            else
            {
                pm.setVisibility(true);
            }

        }
    }
    public void takeDamage(int damage, Vector3 damageDirection)
    {
        if (daamageTakeTime + afterDamageImuneTime < Time.time)
        {
            horizontalDir = gameObject.transform.position - damageDirection;
            if (horizontalDir.y < 0)
            {
                cm._verticalSpeed -= throwSpeed;
            }
            else
            {
                cm._verticalSpeed += throwSpeed;
            }
            horizontalDir = new Vector3(horizontalDir.x, 0, horizontalDir.z);
            Health -= damage;
            daamageTakeTime = Time.time;
            auds.Play();
        }
    }
}
