﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : PlayerAction
{
    public Swim(Player _player) : base(_player)
    {
        player.animator.SetBool("SurfaceSwim", true);
    }

    public override void DoAction()
    {
        base.DoAction();
        //swim
        Vector3 pos = player.transform.position;
        pos.y -= 0.5f;
        if (Input.GetKey(KeyCode.Space) == true) pos.y += 1.0f;
        player.transform.position = pos;
        ///
        //HOW DO WE EXIT SWIMMING ACTION? COLLIDER WITH WATER?
        ///
    }
}
