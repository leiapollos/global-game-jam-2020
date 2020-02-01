using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : PlayerAction
{
    public Climb(Player _player) : base(_player)
    {
    }

    public override void DoAction()
    {
        base.DoAction();
        //climb
        Vector3 pos = player.transform.position;
        pos.y += 1.0f;
        player.transform.position = pos;
        player.action = new ClimbIdle(player);
    }
}
