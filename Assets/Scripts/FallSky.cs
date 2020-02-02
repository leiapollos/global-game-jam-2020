using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSky : PlayerAction
{
    bool hasLanded;
    float oldFollow;

    public FallSky(Player _player) : base(_player)
    {
        sound.PlayLoop(sound.FallingFromSky);
        player.animator.SetTrigger("Falling");
        oldFollow = Camera.main.GetComponent<CameraFollow>().FollowAmount;
        Camera.main.GetComponent<CameraFollow>().FollowAmount = 10;
    }

    public override void DoAction()
    {
        base.DoAction();
        rigidbody.velocity = Vector2.down * player.SkyFallVelocity;
        base.DoAction();
        if (player.isGrounded())
        {
            if (!hasLanded)
            {
                sound.StopLoop();
                GameObject.Find("Music").GetComponent<AudioSource>().Play();
                sound.PlayOnce(sound.ImpactAfterFallSky);
                Camera.main.GetComponent<CameraFollow>().FollowAmount = oldFollow;
                player.animator.SetTrigger("Landing");
                hasLanded = true;
            }
        }
    }
}
