using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpSpeed, fallMultiplier, jumpMultiplier, highJumpMultiplier;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public PlayerAction action;
    public Scenery scenery;
    public float RunVelocity = 4.0f;

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name);
        action.OnTriggerEnter(col);
    }
    public virtual void OnTriggerStay2D(Collider2D col)
    {
        action.OnTriggerStay(col);
    }
    public virtual void OnTriggerExit2D(Collider2D col)
    {
        action.OnTriggerExit(col);
    }

    // Start is called before the first frame update
    void Start()
    {
        action = new Idle(this);
    }

    // Update is called once per frame
    void Update()
    {
        action.DoAction();
    }

    public bool isGrounded()
    {
        var bounds = this.GetComponent<SpriteRenderer>().bounds;
        return Physics2D.BoxCast(
            new Vector2(bounds.min.x + bounds.extents.x, bounds.min.y),
            new Vector2(bounds.extents.x, 0.1f),
            0,
            Vector2.down,
            0.1f,
            ~LayerMask.GetMask("Player")
            ).collider != null;
    }

    public void enableScenery(String name)
    {
        scenery.enableSprite(name);
    }

}
