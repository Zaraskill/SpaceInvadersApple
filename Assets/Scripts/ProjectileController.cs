using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ProjectileController : MonoBehaviour
{
    public float speed = 50;

    

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
            Combo.instance.UpdateCombo(-1);
            Invader[] invaders = FindObjectsOfType<Invader>();
            foreach (Invader invader in invaders)
            {
                invader.DodgeShoot();
            }
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
                Combo.instance.UpdateCombo(1);
                
                collision.gameObject.GetComponent<Invader>().Explode();
            }
        }
    }

}
