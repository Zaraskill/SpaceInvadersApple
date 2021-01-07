using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public static List<Invader> list = new List<Invader>();

    [SerializeField] private GameObject projectile = null;
    [SerializeField] private Canvas ScoreUi = null;
    [SerializeField] private LayerMask mask = 0;

    private float invadersCount = 55;
    private Animator _animator;

    public bool hitSide = false;

    public int scorePoints = 100;

    // Start is called before the first frame update
    void Start()
    {
        list.Add(this);
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 8.5 || transform.position.x < -8.5) hitSide = true;

        else hitSide = false;
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

        _animator.SetBool("isFiring", true);
        StartCoroutine(Fire());
        Instantiate(projectile, transform.position + Vector3.down, Quaternion.identity);
    }

    public void Explode()
    {
        list.Remove(this);
        if (_animator.GetBool("isFiring") || _animator.GetBool("Dodge"))
        {
            StopAllCoroutines();
        }
        _animator.SetBool("Death", true);
        StartCoroutine(Death());
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void DodgeShoot()
    {
        _animator.SetBool("Dodge", false);
        StartCoroutine(Dodge());
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("isFiring", false);
    }

    IEnumerator Dodge()
    {
        yield return new WaitForSeconds(72/120);
        _animator.SetBool("Dodge", false);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.67f);
        float ratio = (invadersCount - (float)list.Count) / invadersCount;
        InvaderManager._instance.moveInterval = Mathf.Lerp(InvaderManager._instance.maxMoveInterval, InvaderManager._instance.minMoveInterval, ratio);
        Instantiate(ScoreUi, transform.position, Quaternion.identity);
        UIManager.instance.ScoreValue += scorePoints;

        if (list.Count == 1)
        {
            InvaderManager._instance.horizontalMoveSpeed = 0.8f;
            AudioManager.instance.IncreasePitch(1.25f);
        }
        else if (list.Count <= 5)
        {
            InvaderManager._instance.horizontalMoveSpeed = 0.6f;
            AudioManager.instance.IncreasePitch(1.1975f);
        }
        else if (list.Count <= 10)
        {
            InvaderManager._instance.horizontalMoveSpeed = 0.3f;
            AudioManager.instance.IncreasePitch(1.125f);
        }
        else if (list.Count <= 15)
        {
            InvaderManager._instance.horizontalMoveSpeed = 0.2f;
            AudioManager.instance.IncreasePitch(1.0625f);
        }
        Destroy(gameObject);
    }
}
