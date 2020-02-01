using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : PlayerAction
{
    bool hasJumped = false;

    public Jump(Player _player) : base(_player)
    {
        player.animator.SetTrigger("Jump");
        sound.PlayOnce(sound.Jumping);
    }

    public override void DoAction()
    {
        base.DoAction();
        if (!hasJumped)
        {
            Vector2 jumpVel = Vector2.up * player.jumpSpeed;
            jumpVel.x = rigidbody.velocity.x;
            rigidbody.velocity = jumpVel;
            hasJumped = true;
        }
        if (rigidbody.velocity.y <= 0)
        {
            player.action = new Fall(player);
        }
        else if (!Input.GetButton("Jump"))
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (player.jumpMultiplier - 1) * Time.deltaTime;
        else
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (player.highJumpMultiplier - 1) * Time.deltaTime;
        Vector3 vel = rigidbody.velocity;
        vel.x = player.RunVelocity * Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = vel;
    }
}
