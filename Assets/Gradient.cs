using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradient : MonoBehaviour
{
    public Transform target;
    public int rate;
    private float initDistance;

    private void Start()
    {
        initDistance = Vector2.Distance(this.transform.position, target.position);
    }

    private void Update()
    {
        Color curr = this.gameObject.GetComponent<SpriteRenderer>().color;
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(curr.r, curr.g, curr.b, 1 - (rate * (Vector2.Distance(this.transform.position, target.position) / initDistance)));

        Debug.Log(Vector2.Distance(this.transform.position, target.position));
    }
}
