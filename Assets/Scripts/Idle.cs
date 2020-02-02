using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : PlayerAction
{
    private float t = 0;
    private float nextT = 0;
    public Idle(Player _player) : base(_player)
    {
        Vector2 vel = rigidbody.velocity;
        vel.x = 0.0f;
        rigidbody.velocity = vel;
        nextT = Random.Range(player.minBreathInterval, player.maxBreathInterval);
    }

    public override void DoAction()
    {
        
        t += Time.deltaTime;
        base.DoAction();
        //idle
        if (t > nextT)
        {
            t = 0;
            nextT = Random.Range(player.minBreathInterval, player.maxBreathInterval);
            sound.PlayOnce(sound.Idle);
        }
        if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            player.action = new Run(player);
        }
        if (Input.GetButtonDown("Jump"))
        {
            player.action = new Jump(player);
        }
        if (Input.GetAxisRaw("Vertical") > 0 && player.CanClimb)//Climb Test
        {
            player.action = new Climb(player);
        }
        if (!player.isGrounded() && rigidbody.velocity.y < 0)
        {
            player.action = new Fall(player);
        }
    }

    public override void OnCollisionEnter(Collision2D col)
    {
        if (col.collider.name == "BlueBucket")
        {
            Debug.Log("11111");
        }
    }
}
