using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public Image lifeOne;
    public Image lifeTwo;
    public Image lifeThree;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lifeOne.gameObject.SetActive(true);
        lifeTwo.gameObject.SetActive(true);
        lifeThree.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLifes(int life)
    {
        if (life == 2)
        {
            lifeThree.gameObject.SetActive(false);
        }
        else if(life == 1)
        {
            lifeTwo.gameObject.SetActive(false);
        }
        else if(life == 0)
        {
            lifeOne.gameObject.SetActive(false);
        }
    }
}
