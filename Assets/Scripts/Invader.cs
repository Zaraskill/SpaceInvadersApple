using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public static List<Invader> list = new List<Invader>();

    // Start is called before the first frame update
    void Start()
    {
        list.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
