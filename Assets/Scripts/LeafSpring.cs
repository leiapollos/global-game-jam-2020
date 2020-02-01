using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpring : MonoBehaviour
{
    // Start is called before the first frame up
    public float bounceForce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = transform.up;
        collision.gameObject.GetComponent<Animator>().SetTrigger("Jump");
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * bounceForce);
        
    }
}
