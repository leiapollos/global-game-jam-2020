using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : PlayerAction
{
    public Climb(Player _player) : base(_player)
    {
        rigidbody.gravityScale = 0;
        player.animator.SetBool("Climb", true);
        player.animator.SetFloat("AnimationSpeed", 1.0f);
    }

    public override void DoAction()
    {
        base.DoAction();
        //climb
        if (Input.GetButton("Jump"))
        {
            rigidbody.gravityScale = 1;
            player.animator.SetBool("Climb", false);
            player.action = new Jump(player);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Vector3 pos = player.transform.position;
            pos.y += 0.05f;
            player.transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 pos = player.transform.position;
            pos.y -= 0.05f;
            player.transform.position = pos;
            if (player.isGrounded())
            {
                rigidbody.gravityScale = 1;
                player.animator.SetBool("Climb", false);
                player.action = new Idle(player);
            }
        }
        else 
        {
            player.action = new ClimbIdle(player);
        }
    }
}
