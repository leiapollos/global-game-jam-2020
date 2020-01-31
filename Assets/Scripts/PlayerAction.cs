using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction
{
    protected Player player;

    public PlayerAction(Player _player)
    {
        player = _player;
    }

    public virtual void DoAction() { }
}
