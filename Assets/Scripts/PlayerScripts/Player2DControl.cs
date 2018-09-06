﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2DControl : MonoBehaviour
{
    public float MoveForce = 5;
    public GameObject shot;
    public Transform rPos01;
    public GameObject shot1;
    public Transform rPos02;
    public static float nextFire;
    public AudioSource BotRocketHit;
    public AudioClip BotHitClip;
    [SerializeField]
    Rigidbody2D myBody;
    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 moveVec = new Vector3((CrossPlatformInputManager.GetAxis("Horizontal") * MoveForce * 10),
                  (CrossPlatformInputManager.GetAxis("Vertical"))
                  * MoveForce * 10);
        Vector3 lookVec = new Vector3((CrossPlatformInputManager.GetAxis("Horizontal")),
            (CrossPlatformInputManager.GetAxis("Vertical")), 4096);
        if (lookVec.x != 0 && lookVec.y != 0)
            transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);
        myBody.AddForce(moveVec);
        myBody.AddForce(lookVec);

    }
    public void shoot()
    {
        if (Time.time >= nextFire && AmmoCounter.AmmodownRocket > 0)
        {
            nextFire = Time.time + 5;
            GameObject clone = Instantiate(shot, rPos01.position, rPos01.rotation);
            GameObject clone2 = Instantiate(shot1, rPos02.position, rPos02.rotation);
            clone.SetActive(true);
            clone2.SetActive(true);
            Destroy(clone, 5f);
            Destroy(clone2, 5f);
            AmmoCounter.AmmodownRocket -= 1;
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



