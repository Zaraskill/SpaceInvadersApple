using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{

    public static LoseScreen instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField] private Button RestartButton;
    [SerializeField] private Button ExitButton;
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Restart()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
