using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public static List<Invader> list = new List<Invader>();

    [SerializeField] private GameObject projectile;
    [SerializeField] private LayerMask mask;

    private float invadersCount = 55;

    public bool hitSide = false;

    public int scorePoints = 100;

    // Start is called before the first frame update
    void Start()
    {
        list.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CheckForward()
    {
        if(!Physics2D.Raycast(transform.position, Vector2.down, 1f, mask))
        {
            return false;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, mask);

        if (hit.collider.tag != "Enemy") return false;

        if (hit.transform.gameObject.GetComponent<Invader>())
        {
            hit.transform.gameObject.GetComponent<Invader>().Shoot();
            return true;
        }
        else return false;
    }

    public void Shoot()
    {
        //if (CheckForward()) return;
        AudioManager.instance.PlayEnemyShot();
        Instantiate(projectile, transform.position + Vector3.down, Quaternion.identity);
    }

    public void Explode()
    {
        list.Remove(this);
        float ratio = (invadersCount - (float)list.Count) / invadersCount;
        InvaderManager._instance.moveInterval = Mathf.Lerp(InvaderManager._instance.maxMoveInterval, InvaderManager._instance.minMoveInterval, ratio);
        UIManager.instance.ScoreValue += scorePoints;
        UIManager.instance.UpdateScore();

        if (list.Count == 1)
        {
            InvaderManager._instance.horizontalMoveSpeed = 0.8f;
            AudioManager.instance.IncreasePitch(2f);
        }
        else if (list.Count <= 5)
        {
            InvaderManager._instance.horizontalMoveSpeed = 0.6f;
            AudioManager.instance.IncreasePitch(1.75f);
        }
        else if (list.Count <= 10)
        {
            InvaderManager._instance.horizontalMoveSpeed = 0.3f;
            AudioManager.instance.IncreasePitch(1.5f);
        }
        else if (list.Count <= 15)
        {
            InvaderManager._instance.horizontalMoveSpeed = 0.2f;
            AudioManager.instance.IncreasePitch(1.25f);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sides"))
        {
            hitSide = true;
        }
    }
}
