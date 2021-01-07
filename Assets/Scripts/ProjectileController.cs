﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ProjectileController : MonoBehaviour
{
    public float speed = 50;

    [Header("Camera Shaker")]
    public float magnitude;
    public float roughness;
    public float fadeInTime;
    public float fadeOutTime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            AudioManager.instance.PlayEnemyTrash();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            if (collision.gameObject.GetComponent<Invader>())
            {
                AudioManager.instance.PlayEnemyDeath();
                CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
                collision.gameObject.GetComponent<Invader>().Explode();
            }
        }
    }

}
