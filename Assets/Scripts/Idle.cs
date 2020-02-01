using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : PlayerAction
{
    public Idle(Player _player) : base(_player)
    {
    }

    public override void DoAction()
    {
        //idle
        if (Input.GetAxisRaw("Horizontal")>0.0f) {
            player.action = new RunRight(player);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0.0f){
            player.action = new RunLeft(player);
        }
        if (Input.GetButtonDown("Jump"))
        {
            player.action = new Jump(player);
        }
        player.GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (player.fallMultiplier - 1) * Time.deltaTime;
    }
}
