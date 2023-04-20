using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonProj : MonoBehaviour
{
    public Vector2 target;
    private Vector2 start;
    [SerializeField] float travelTime;
    [SerializeField] float maxHeight;
    [SerializeField] AnimationCurve curve;
    [SerializeField] GameObject poisonPuddle;
    private float timePass;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timePass += Time.deltaTime;
        var timeProgress = timePass / travelTime;
        float heightCurve = curve.Evaluate(timeProgress);
        var height = Mathf.Lerp(0f, maxHeight, heightCurve);
        transform.position = Vector2.Lerp(start, target, timeProgress) + new Vector2(0f, height);
        if (timeProgress >= 1)
        {
            Instantiate(poisonPuddle, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(this.gameObject);
        }
    }

}
