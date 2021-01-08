using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUi : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private AnimationCurve moveCurve;
    [SerializeField] private AnimationCurve scaleCurve;

    private Vector3 arrival = new Vector3(-6.3f, 4.3f, 0);

    public float moveTimer = 0.6f;

    private float elapsedTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, arrival, moveCurve.Evaluate(elapsedTime / moveTimer));
        transform.localScale = new Vector3(scaleCurve.Evaluate(elapsedTime), scaleCurve.Evaluate(elapsedTime), 1);
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= moveTimer/2)
        {          
            Destroy(gameObject);
            UIManager.instance.UpdateScore();
        }
    }
}
