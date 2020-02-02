using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : PlayerAction
{
    public override void OnTriggerExit(Collider2D col)
    {
        if (col.CompareTag("Climbable"))
        {
            sound.StopLoop();
            rigidbody.gravityScale = 1;
            player.animator.SetBool("Climb", false);
            player.action = new Jump(player);
        }
    }

    public Climb(Player _player) : base(_player)
    {
        sound.PlayLoop(sound.Climbing);
        rigidbody.gravityScale = 0;
        rigidbody.velocity = Vector2.zero;
        player.animator.SetBool("Climb", true);
        player.animator.SetFloat("AnimationSpeed", 1.0f);
    }

    public override void DoAction()
    {
        base.DoAction();
        //climb
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.gravityScale = 1;
            player.animator.SetBool("Climb", false);
            sound.StopLoop();
            player.action = new Jump(player);
        }
        else if (player.isGrounded() && Input.GetAxisRaw("Vertical") < 0)
        {
            rigidbody.gravityScale = 1;
            player.animator.SetBool("Climb", false);
            sound.StopLoop();
            player.action = new Idle(player);
        }
        else if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            var dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            rigidbody.MovePosition(rigidbody.position + dir * player.climbSpeed * Time.deltaTime);
        }
        else
        {
            sound.StopLoop();
            player.action = new ClimbIdle(player);
        }
    }
}
