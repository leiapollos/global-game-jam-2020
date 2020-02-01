using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction
{
    protected Player player;
    protected Rigidbody2D rigidbody;

    public PlayerAction(Player _player)
    {
        player = _player;
        rigidbody = player.GetComponent<Rigidbody2D>();
    }

    public virtual void OnCollisionEnter(Collision2D col) {

    }
    public virtual void OnCollisionStay(Collision2D col) {
        
    }
    public virtual void OnCollisionExit(Collision2D col) {
        
    }
    public virtual void DoAction() {
        //Flipping Sprite:
        if (player.spriteRenderer.flipX && rigidbody.velocity.x > player.RunVelocity - 1) player.spriteRenderer.flipX = false;
        else if (!player.spriteRenderer.flipX && rigidbody.velocity.x < - (player.RunVelocity - 1)) player.spriteRenderer.flipX = true;
    }
}
