using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafJump : PlayerAction
{
    bool hasLanded;
    bool isFalling;
    public LeafJump(Player _player, Vector2 force) : base(_player)
    {
        player.animator.SetTrigger("Jump");
        rigidbody.AddForce(force);
    }

    public override void DoAction()
    {
        base.DoAction();

        if (player.isGrounded())
        {

            if (!hasLanded)
            {
                rigidbody.velocity = Vector2.zero;
                player.animator.SetTrigger("Landing");
                hasLanded = true;
            }
        }
        else if (Input.GetAxisRaw("Vertical") > 0 && player.CanClimb)
        {
            player.action = new Climb(player);
        }
        else
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (player.jumpMultiplier - 1) * Time.deltaTime;
            rigidbody.AddForce(Vector2.right * Input.GetAxisRaw("Horizontal") * player.SpringForce * Time.deltaTime);
            if(rigidbody.velocity.y < 0 && !isFalling)
            {
                player.animator.SetTrigger("Falling");
                isFalling = true;
            }
        }
    }
}
