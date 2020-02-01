using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbIdle : PlayerAction
{
    public ClimbIdle(Player _player) : base(_player)
    {
    }

    public override void DoAction()
    {
        base.DoAction();
        //climbidle
        if (Input.GetKey(KeyCode.W))
        {
            player.action = new Climb(player);
        }
    }
}
