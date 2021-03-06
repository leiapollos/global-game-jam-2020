﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : PlayerAction
{
    public Run(Player _player) : base(_player)
    {
        player.animator.SetBool("Run", true);
        Debug.Log("Run");
        sound.PlayLoop(sound.Running);
    }

    public override void DoAction()
    {
        base.DoAction();
        //run

        Vector3 vel = rigidbody.velocity;
        vel.x = player.RunVelocity * Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Jump") && player.isGrounded())
        {
            player.isGrounded();
            sound.StopLoop();
            player.action = new Jump(player);
            player.animator.SetBool("Run", false);
        }
        rigidbody.velocity = vel;
        if (Input.GetAxisRaw("Horizontal") == 0.0f)
        {
            sound.StopLoop();
            player.action = new Idle(player);
            player.animator.SetBool("Run", false);
        }
        if (!player.isGrounded() && rigidbody.velocity.y < 0)
        {
            sound.StopLoop();
            player.animator.SetBool("Run", false);
            player.action = new Fall(player);
        }
    }
}
