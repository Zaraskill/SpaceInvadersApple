using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private int direction;
    private Rigidbody2D _rigidbody;
    private bool canShoot;
    private GameObject shoot;


    public int life = 3;
    public float speed;
    public GameObject projectile;

    public static Action OnShoot;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        UpdateMovement();
        if(shoot == null)
        {
            canShoot = true;
        }
    }

    private void UpdateInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            AudioManager.instance.PlayPlayerShot();
            canShoot = false;
            Shoot();
        }
    }

    private void UpdateMovement()
    {
        float movement = direction * speed;
        transform.position += new Vector3(0.01f * movement, 0, 0);
    }

    private void Shoot()
    {
        GameObject missile = Instantiate(projectile);
        shoot = missile;
        missile.transform.position = transform.position + Vector3.up * 2;
        OnShoot?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            life--;
            Destroy(collision.gameObject);
            UIManager.instance.UpdateLifes(life);
            if(life <= 0)
            {
                //Gameover
            }
            else
            {
                AudioManager.instance.PlayEnemyTrash();
                AudioManager.instance.PlayPlayerDeath();
            }
        }
    }
}
