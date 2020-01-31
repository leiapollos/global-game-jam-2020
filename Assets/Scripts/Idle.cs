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
        base.DoAction();
        //idle
    }
}
