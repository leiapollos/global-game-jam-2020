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
    }
}
