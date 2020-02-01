using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbIdle : PlayerAction
{
    public ClimbIdle(Player _player) : base(_player)
    {
        player.animator.SetFloat("AnimationSpeed", 0.0f);
    }

    public override void DoAction()
    {
        base.DoAction();
        if (Input.GetButton("Jump"))
        {
            player.animator.SetFloat("AnimationSpeed", 1.0f);
            rigidbody.gravityScale = 1;
            player.animator.SetBool("Climb", false);
            player.action = new Idle(player);
        }
        else if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            player.action = new Climb(player);
        }
    }
}
