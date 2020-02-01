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
    public float RunVelocity = 4.0f;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        action.OnCollisionEnter(col);
    }
    public virtual void OnCollisionStay2D(Collision2D col)
    {
        action.OnCollisionStay(col);
    }
    public virtual void OnCollisionExit2D(Collision2D col)
    {
        action.OnCollisionExit(col);
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
            ).collider;
    }
}
