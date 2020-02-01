using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : PlayerAction
{
    bool hasLanded;

    public Fall(Player _player) : base(_player)
    {
        player.animator.SetTrigger("Falling");
    }

    public override void DoAction()
    {
        base.DoAction();
        rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (player.fallMultiplier - 1) * Time.deltaTime;
        base.DoAction();
        if (player.isGrounded())
        {
            if (!hasLanded)
            {
                player.animator.SetTrigger("Landing");
                hasLanded = true;
            }
        }
        else
        {
            Vector3 vel = rigidbody.velocity;
            vel.x = player.RunVelocity * Input.GetAxisRaw("Horizontal");
            rigidbody.velocity = vel;
        }
    }
}
