using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : PlayerAction
{
    Jumping(Player _player)
    {
        player = _player;
    }

    public override void DoAction()
    {
        base.DoAction();
        //JUMP
    }
}
