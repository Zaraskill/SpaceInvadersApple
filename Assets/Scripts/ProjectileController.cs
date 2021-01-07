using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 50;
    public GameObject particleExplosion;

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
            Instantiate(particleExplosion, collision.gameObject.transform.position, Quaternion.identity);
            if (collision.gameObject.GetComponent<Invader>())
            {
                AudioManager.instance.PlayEnemyDeath();
                UIManager.instance.BloodStain(collision.gameObject.transform.position);
                collision.gameObject.GetComponent<Invader>().Explode();
            }
        }
    }

}
