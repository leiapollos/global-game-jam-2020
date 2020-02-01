using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpSpeed, fallMultiplier, jumpMultiplier, highJumpMultiplier;
    public float climbSpeed = 0.05f;
    public float SpringForce = 1f;

    public float swimSpeed = 1f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public PlayerAction action;
    public Scenery scenery;
    public float RunVelocity = 4.0f;

    public bool CanClimb;

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Climbable"))
            CanClimb = true;
        action.OnTriggerEnter(col);
    }
    public virtual void OnTriggerStay2D(Collider2D col)
    {
        action.OnTriggerStay(col);
    }
    public virtual void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Climbable"))
            CanClimb = false;
        action.OnTriggerExit(col);
    }

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
        Vector2 S = spriteRenderer.bounds.size;
        GetComponent<BoxCollider2D>().size = S;
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
            ~LayerMask.GetMask("Player", "Climbable")
            ).collider != null;
    }

    public void enableScenery(String name)
    {
        scenery.enableSprite(name);
    }

    public void GoToIdle()
    {
        action = new Idle(this);
    }

}
