using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbColor : PlayerAction
{
    public AbsorbColor(Player _player) : base(_player)
    {
        player.animator.SetBool("Run", false);
        player.animator.SetBool("DeepSwim", false);
        player.animator.SetBool("SurfaceSwim", false);
        player.animator.SetBool("Climb", false);
        player.animator.SetBool("ClimbIdle", false);
        player.animator.SetTrigger("AbsorbColor");
    }

    public override void DoAction()
    {
        base.DoAction();
        //run
        if (player.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            player.action = new Idle(player);
        }
    }
}
