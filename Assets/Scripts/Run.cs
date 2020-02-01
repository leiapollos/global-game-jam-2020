using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : PlayerAction
{
    public Run(Player _player) : base(_player)
    {

    }

    public override void DoAction()
    {
        //run

        Vector3 vel = rigidbody.velocity;
        if (Input.GetAxisRaw("Horizontal") > 0.0f)
        {
            vel.x = player.RunVelocity;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            vel.x = - player.RunVelocity;
        }
        if (Input.GetButton("Jump"))
        {
            player.action = new Jump(player);
        }
        rigidbody.velocity = vel;
        if(Input.GetAxisRaw("Horizontal") == 0.0f)
            player.action = new Idle(player);
    }
}
