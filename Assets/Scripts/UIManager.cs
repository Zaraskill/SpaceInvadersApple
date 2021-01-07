using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public Image lifeOne;
    public Image lifeTwo;
    public Image lifeThree;
    

    public TMP_Text ScoreText;
    public int ScoreValue;

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

    public void UpdateScore()
    {
        ScoreText.text = "Score : " + ScoreValue; 
    }

    public void BloodStain(Vector3 position, GameObject blood)
    {
        GameObject image = Instantiate(blood, this.GetComponent<RectTransform>());
        RectTransform transformRect = image.GetComponent<RectTransform>();
        transformRect.position = position;
        float scale = Random.Range(0.5f, 2f);
        transformRect.localScale = new Vector3(scale, scale, 0);
        float rotation = Random.Range(0, 360);
        transformRect.Rotate(new Vector3(0, 0, rotation));
    }
}
