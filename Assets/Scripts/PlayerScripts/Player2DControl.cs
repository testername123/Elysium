﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2DControl : MonoBehaviour
{
    public float MoveForce = 5, _firstammo;
    [SerializeField]
    public GameObject shot, Zero_ammo;
    private string ammo;
    public Transform rPos01;
    public GameObject shot1;
    public Transform rPos02;
    public static float nextFire;
    public AudioSource BotRocketHit;
    public AudioClip BotHitClip;
    [SerializeField]
    private Image Fill;
    private Rigidbody2D myBody;
    private bool IsPressed;
    void Start()
    {
        _firstammo = AmmoCounter.AmmodownRocket;
        myBody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsPressed)
            shoot();
        else if (!IsPressed &&  AmmoCounter.AmmodownRocket < _firstammo)
        {
            ammo = (AmmoCounter.AmmodownRocket += 0.1f * Time.deltaTime).ToString("F3");
            AmmoCounter.AmmodownRocket = float.Parse(ammo);
        }
    }

    void FixedUpdate()
    {
        Vector3 moveVec = new Vector3((CrossPlatformInputManager.GetAxis("Horizontal") * MoveForce * 10),
                  (CrossPlatformInputManager.GetAxis("Vertical"))
                  * MoveForce * 10);
        Vector3 lookVec = new Vector3((CrossPlatformInputManager.GetAxis("Horizontal")),
            (CrossPlatformInputManager.GetAxis("Vertical")), 4096);
        float turn = CrossPlatformInputManager.GetAxis("Horizontal");
        if (lookVec.x != 0 && lookVec.y != 0)
            myBody.transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);
        myBody.AddForce(moveVec);
        myBody.AddForce(lookVec);
    }

    public void IsClicked()
    {
        IsPressed = true;
    }

    public void UnClicked()
    {
        IsPressed = false;
    }
    public void shoot()
    {
        if (Time.time >= nextFire && AmmoCounter.AmmodownRocket > 0)
        {
            if(BotDifficult.noob)
                nextFire = Time.time + 3;
            if (BotDifficult.abitharder)
                nextFire = Time.time + 4;
            if (BotDifficult.impossible)
                nextFire = Time.time + 5;

            GameObject clone = Instantiate(shot, rPos01.position, rPos01.rotation);
            GameObject clone2 = Instantiate(shot1, rPos02.position, rPos02.rotation);
            clone.SetActive(true);
            clone2.SetActive(true);
            Destroy(clone, 5f);
            Destroy(clone2, 5f);
            AmmoCounter.AmmodownRocket -= 1;
            Fill.fillAmount = 0.2f * Time.time;
        }
        if(AmmoCounter.AmmodownRocket <= 0)
        {

            Zero_ammo.SetActive(true);
           
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "botrocket")
        {
            BotRocketHit.PlayOneShot(BotHitClip);
        }

    }
}




