using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderManager : MonoBehaviour
{
    [SerializeField] private float shootFrequency = 2f;

    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float moveInterval = 2f;

    private float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= moveInterval)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.down, moveSpeed);
            elapsedTime = 0;
        }  
    }
}
