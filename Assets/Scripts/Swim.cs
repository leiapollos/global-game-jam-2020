using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : PlayerAction
{
    bool surface;
    bool surfacePrev;
    protected float swimFallMultiplier = 0.5f;
    public Swim(Player _player) : base(_player)
    {
        sound.PlayLoop(sound.SurfaceSwim);
        player.animator.SetBool("SurfaceSwim", true);
        player.adaptCollider = true;
    }

    public override void DoAction()
    {
        base.DoAction();
        if (surface != surfacePrev)
        {
            if (surface)
                sound.PlayLoop(sound.SurfaceSwim);
            else
                sound.PlayLoop(sound.DeepSwim);
        }
        surfacePrev = surface;
        //swim
        //player.GetComponent<Rigidbody2D>().velocity += Vector2.up * Physics2D.gravity.y * (swimFallMultiplier) * Time.deltaTime;
        Vector2 vel = player.GetComponent<Rigidbody2D>().velocity;
        if (Input.GetButton("Jump"))
            vel.y = player.swimSpeed;
        else
            vel.y = -player.swimSpeed;

        vel.x = player.RunVelocity * Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = vel;

        player.GetComponent<Rigidbody2D>().velocity = vel;
    }

    public override void OnTriggerEnter(Collider2D col)
    {
        if (col.tag == "WaterSurface")
        {
            surface = true;
            player.animator.SetBool("DeepSwim", false);
            player.animator.SetBool("SurfaceSwim", true);
        }
    }

    public override void OnTriggerStay(Collider2D col)
    {
        if (col.tag == "WaterSurface")
        {
            player.animator.SetBool("DeepSwim", false);
            player.animator.SetBool("SurfaceSwim", true);
        }
        else if (col.tag == "Water")
        {
            player.animator.SetBool("DeepSwim", true);
        }
    }

    public override void OnTriggerExit(Collider2D col)
    {
        if (col.tag == "Water")
        {
            sound.StopLoop();
            player.animator.SetBool("DeepSwim", false);
            player.animator.SetBool("SurfaceSwim", false);
            player.action = new Idle(player);
            player.adaptCollider = false;
        }
        else if (col.tag == "WaterSurface")
        {
            surface = false;
        }
    }

}
