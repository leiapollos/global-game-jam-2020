﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction
{
    protected Player player;
    protected Rigidbody2D rigidbody;
    protected PlayerAudio sound;

    public PlayerAction(Player _player)
    {
        player = _player;
        sound = player.sound;
        rigidbody = player.GetComponent<Rigidbody2D>();
    }

    public virtual void OnCollisionEnter(Collision2D col)
    {

    }
    public virtual void OnCollisionStay(Collision2D col)
    {

    }
    public virtual void OnCollisionExit(Collision2D col)
    {

    }

    public virtual void OnTriggerEnter(Collider2D col)
    {
        if (col.name == "BlueBucket")
        {
            player.DrinkAnimation(col.gameObject);
            col.gameObject.GetComponentInChildren<Transform>().gameObject.SetActive(false);

        }
        if (col.tag == "Water")
        {
            player.eyes.enabled = false;
            player.animator.SetBool("Run", false);
            player.action = new Swim(player);
        }
    }
    public virtual void OnTriggerStay(Collider2D col)
    {

    }
    public virtual void OnTriggerExit(Collider2D col)
    {

    }

    public virtual void DoAction()
    {
        //Flipping Sprite:
        if (player.spriteRenderer.flipX && rigidbody.velocity.x > player.RunVelocity - 1) player.spriteRenderer.flipX = false;
        else if (!player.spriteRenderer.flipX && rigidbody.velocity.x < -(player.RunVelocity - 1)) player.spriteRenderer.flipX = true;
    }


}
