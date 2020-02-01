using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : PlayerAction
{
    bool hasJumped = false;
    Rigidbody2D rb;

    public Jump(Player _player) : base(_player)
    {
        rb = player.GetComponent<Rigidbody2D>();
        player.animator.SetTrigger("Jump");
    }

    public override void DoAction()
    {
        base.DoAction();
        if (!hasJumped)
        {
            Vector2 jumpVel = Vector2.up * player.jumpSpeed;
            jumpVel.x = rigidbody.velocity.x;
            rb.velocity = jumpVel;
            hasJumped = true;
        }
        if (rb.velocity.y <= 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (player.fallMultiplier - 1) * Time.deltaTime;
            if (player.isGrounded())
            {
                Debug.Log("oof");
                player.action = new Idle(player);
                player.animator.SetTrigger("Landing");
            }
        }
        else if (!Input.GetButton("Jump"))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (player.jumpMultiplier - 1) * Time.deltaTime;
        else
            rb.velocity += Vector2.up * Physics2D.gravity.y * (player.highJumpMultiplier - 1) * Time.deltaTime;
        Vector3 vel = rigidbody.velocity;
        vel.x = player.RunVelocity * Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = vel;
    }
}
