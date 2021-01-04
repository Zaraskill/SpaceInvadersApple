using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private int direction;
    private Rigidbody2D _rigidbody;

    public float speed;
    public GameObject projectile;

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
    }

    private void UpdateInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
        //Instantiate(projectile);
        //projectile.transform.position += Vector3.up;
    }
}
