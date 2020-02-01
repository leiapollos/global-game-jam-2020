using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : PlayerAction
{
    bool hasJumped = false;
    Rigidbody2D rb;

    public Jump(Player _player) : base(_player)
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    Bounds GetBounds()
    {
        return player.GetComponent<SpriteRenderer>().bounds;
    }

    public override void DoAction()
    {
        base.DoAction();
        if (!hasJumped)
        {
            rb.velocity = Vector2.up * player.jumpSpeed;
            hasJumped = true;
        }
        if (rb.velocity.y <= 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (player.fallMultiplier - 1) * Time.deltaTime;
            var bounds = GetBounds();
            if (Physics2D.BoxCast(
            new Vector2(bounds.min.x + bounds.extents.x, bounds.min.y),
            new Vector2(bounds.extents.x, 0.1f),
            0,
            Vector2.down,
            0.1f,
            ~LayerMask.GetMask("Player")
            ).collider)
            {
                Debug.Log("oof");
                player.action = new Idle(player);
            }
        }
        else if (!Input.GetButton("Jump"))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (player.jumpMultiplier - 1) * Time.deltaTime;
        else
            rb.velocity += Vector2.up * Physics2D.gravity.y * (player.highJumpMultiplier - 1) * Time.deltaTime;
    }
}
