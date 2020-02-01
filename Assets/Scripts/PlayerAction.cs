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

    public virtual void OnTriggerEnter(Collider2D col) {
        if (col.name == "BlueBucket")
        {
            GameObject.Destroy(col.gameObject);
            player.enableScenery("Water");
        }
        if(col.name == "Water")
        {
            player.animator.SetBool("Run", false);
            player.action = new Swim(player);
        }
    }
    public virtual void OnTriggerStay(Collider2D col) {
        
    }
    public virtual void OnTriggerExit(Collider2D col) {
        
    }

    public virtual void DoAction() {
        //Flipping Sprite:
        if (player.spriteRenderer.flipX && rigidbody.velocity.x > player.RunVelocity - 1) player.spriteRenderer.flipX = false;
        else if (!player.spriteRenderer.flipX && rigidbody.velocity.x < - (player.RunVelocity - 1)) player.spriteRenderer.flipX = true;
    }
}
