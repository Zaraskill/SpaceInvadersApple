using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderManager : MonoBehaviour
{
    public static InvaderManager _instance;

    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    [SerializeField] private float shootFrequency = 2f;

    public float horizontalMoveSpeed = 0.1f;
    public float verticalMoveSpeed = 0.2f;
    [HideInInspector] public float moveInterval = 1.5f;
    public float maxMoveInterval = 1.5f;
    public float minMoveInterval = 0.1f;

    private Vector3 verticalOrientation = Vector3.left;

    private float elapsedTime = 0;
    private float elapsedTimeShoot = 0;

    // Start is called before the first frame update
    void Start()
    {
        moveInterval = maxMoveInterval;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= moveInterval)
        {
            for(int i = Invader.list.Count-1; i >= 0; i--)
            {
                if (Invader.list[i].hitSide)
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down, verticalMoveSpeed);
                    for (int j = Invader.list.Count - 1; j >= 0; j--)
                    {
                        Invader.list[j].hitSide = false;
                    }
                    if (verticalOrientation == Vector3.left) verticalOrientation = Vector3.right;
                    else if (verticalOrientation == Vector3.right) verticalOrientation = Vector3.left;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, transform.position + verticalOrientation, horizontalMoveSpeed);
            elapsedTime = 0;
        }

        elapsedTimeShoot += Time.deltaTime;

        if (elapsedTimeShoot >= shootFrequency)
        {
            int invaderSelected = (int)Random.Range(0, Invader.list.Count-1);
            Invader.list[invaderSelected].Shoot();
            elapsedTimeShoot = 0;
        }
    }
}
