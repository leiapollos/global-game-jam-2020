using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : PlayerAction
{
    public Idle(Player _player) : base(_player)
    {
        Vector2 vel = rigidbody.velocity;
        vel.x = 0.0f;
        rigidbody.velocity = vel;
    }

    public override void DoAction()
    {
        //idle
        if (Input.GetAxisRaw("Horizontal")!=0.0f) {
            player.action = new Run(player);
        }
        if (Input.GetButtonDown("Jump"))
        {
            player.action = new Jump(player);
        }
        player.GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (player.fallMultiplier - 1) * Time.deltaTime;
    }
}
