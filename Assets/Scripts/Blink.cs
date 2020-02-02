using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Sprite Open, Closed;
    public float MinInterval = 1.0f, MaxInterval = 4.0f;
    public float BlinkTime = 0.2f;
    private float t, nextT;
    private SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        t = 0;
        nextT = Random.Range(MinInterval, MaxInterval);
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > nextT)
        {
            t = 0;
            nextT = Random.Range(MinInterval, MaxInterval);
            StartCoroutine(Close());
        }
    }

    private IEnumerator Close()
    {
        spr.sprite = Closed;
        yield return new WaitForSeconds(BlinkTime);
        spr.sprite = Open;
    }
}
