﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerRigibady : MonoBehaviour
{
    public float speed = 1f;
    public float rotSpeed = 30f;
    Rigidbody rb;
    float newRotY = 0;
    public GameObject prefabBullet;
    public Transform gunPosition;
    public float gun = 15f;
    public float gunCooldown = 2f;
    public float gunCooldownCount = 0;
    public bool hasGun = false;
    public int coinCount = 0;
    public Playground manager;
    public int bulletCount = 0;
    public AudioSource audioCoin;
    public AudioSource audioFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = FindObjectOfType<Playground>();
        if(manager == null)
        {
            print("Manager not found!");
        }
        if(PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }
        manager.SetTextCoin(coinCount);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal")*speed;
        float vertical = Input.GetAxis("Vertical")*speed;
        if(horizontal>0)
        {
            newRotY = -90;
        }
        if (horizontal < 0)
        {
            newRotY = 90;
        }
        if (vertical > 0)
        {
            newRotY = -180;
        }
        if (vertical < 0)
        {
            newRotY = 0;
        }
        rb.AddForce(horizontal, 0, vertical, ForceMode.VelocityChange);
        transform.rotation = Quaternion.Lerp(
                                                Quaternion.Euler(0, newRotY, 0),
                                                transform.rotation,
                                                rotSpeed * Time.deltaTime
                                             );
    }


     private void Update()
    {
        gunCooldownCount += Time.deltaTime;
        //ยิงปืน
        if (Input.GetButtonDown("Fire1") && hasGun && (bulletCount>0) &&( gunCooldownCount >= gunCooldown))
        {
            gunCooldownCount = 0;
            GameObject bullet = Instantiate(prefabBullet, gunPosition.position, gunPosition.rotation);
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 15f, ForceMode.Impulse);
            Rigidbody bRb = bullet.GetComponent<Rigidbody>();
            bRb.AddForce(transform.forward * -gun, ForceMode.Impulse);
            Destroy(bullet, 2f);

            bulletCount--;
            manager.SetTextBullet(bulletCount);
            audioFire.Play();

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "collectable")
        {
            Destroy(collision.gameObject);
          
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collectable")
        {
            Destroy(other.gameObject);
            coinCount++;
            manager.SetTextCoin(coinCount);
            audioCoin.Play();
            PlayerPrefs.SetInt("CoinCount", coinCount);
        }
        if(other.gameObject.tag == "gun2")
        {
            print("Yeah I have a gun!");
            Destroy(other.gameObject);
            hasGun = true;
            bulletCount += 10;
            manager.SetTextBullet(bulletCount);

        }
    }
}
