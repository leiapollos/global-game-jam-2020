using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : PlayerAction
{
    protected float swimFallMultiplier = 0.5f;
    public Swim(Player _player) : base(_player)
    {
        player.animator.SetBool("SurfaceSwim", true);
        Debug.Log("444444444");
    }

    public override void DoAction()
    {
        base.DoAction();
        //swim
        player.GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (swimFallMultiplier) * Time.deltaTime;
        Vector2 vel = player.GetComponent<Rigidbody2D>().velocity;
        if (Input.GetButton("Jump")) vel.y += 0.8f;
        ///
        //HOW DO WE EXIT SWIMMING ACTION? COLLIDER WITH WATER?
        ///
        if (vel.y < -1.0f)
            vel.y = -1.0f; 
        if (vel.y > 1.0f)
            vel.y = 1.0f;

        vel.x = player.RunVelocity * Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = vel;

        player.GetComponent<Rigidbody2D>().velocity = vel;
    }

    public override void OnTriggerStay(Collider2D col)
    {
        if(col.name == "WaterSurface")
        {
            player.animator.SetBool("DeepSwim", false);
            player.animator.SetBool("SurfaceSwim", true);
        }
        else if(col.name == "Water")
        {
            player.animator.SetBool("DeepSwim", true);
        }
        else
        {
            player.action = new Idle(player);
        }
    }

}
