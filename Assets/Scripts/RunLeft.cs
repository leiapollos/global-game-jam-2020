using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLeft : PlayerAction
{
    public RunLeft(Player _player) : base(_player)
    {

    }

    public override void DoAction()
    {
        //run
        Vector3 vel = rigidbody.velocity;
        vel.x = - player.RunVelocity;
        rigidbody.velocity = vel;
        player.action = new Idle(player);
    }
}
