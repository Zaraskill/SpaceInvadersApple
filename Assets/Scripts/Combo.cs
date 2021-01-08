using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public static Combo instance;

    private int combo = 0;
    private ShipController ship;

    [Header("Emojis")]
    public List<GameObject> badEmojis;
    public List<GameObject> goodEmojis;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ship = FindObjectOfType<ShipController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCombo(int action)
    {
        if (FeaturesManager.instance.feature8 % 2 == 0)
        {
            return;
        }

        if (action > 0)
        {
            if (combo <= 0)
            {
                combo = action;
            }
            else
            {
                combo += action;
            }
        }
        else
        {
            if (combo >= 0)
            {
                combo = action;
            }
            else
            {
                combo += action;
            }
        }
        if (combo%4 == 0)
        {
            GameObject emoji;
            if (action > 0)
            {
                emoji = goodEmojis[Random.Range(0, goodEmojis.Count)];
                AudioManager.instance.PlayPositiveFeedbacks();
            }
            else
            {
                emoji = badEmojis[Random.Range(0, badEmojis.Count)];
                AudioManager.instance.PlayNegativeFeedbacks();
            }
            ship.FeedbackEmoji(emoji);
            UIManager.instance.TrashtalkPlayer(action);
        }
    }
}
