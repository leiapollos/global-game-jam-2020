using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpring : MonoBehaviour
{
    // Start is called before the first frame up
    public float bounceForce;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.volume = 0.5f;
        audio.Play();
        Vector2 direction = transform.up.normalized;
        var player = collision.gameObject.GetComponent<Player>();
        player.action = new LeafJump(player, direction * bounceForce);

    }
}
