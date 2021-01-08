using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FeaturesManager : MonoBehaviour
{

    public static FeaturesManager instance;

    public int feature1 = 0;
    public int feature2 = 0;
    public int feature3 = 0;
    public int feature4 = 0;
    public int feature5 = 0;
    public int feature6 = 0;
    public int feature7 = 0;
    public int feature8 = 0;

    public PostProcessLayer postprocess;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            feature1++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            feature2++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            feature3++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            feature4++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            feature5++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            feature6++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            feature7++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            feature8++;
        }

        UpdatePostProcess();
        
    }

    public void UpdatePostProcess()
    {
        if (FeaturesManager.instance.feature5 % 2 == 0)
        {
            postprocess.enabled = false;
        }
        else
        {
            postprocess.enabled = true;
        }
    }
}
