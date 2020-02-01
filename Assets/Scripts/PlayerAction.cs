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

    public virtual void DoAction() { }
}
