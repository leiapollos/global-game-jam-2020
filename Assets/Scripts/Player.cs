using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpSpeed, fallMultiplier, jumpMultiplier, highJumpMultiplier;

    public PlayerAction action;
    public float RunVelocity = 4.0f;

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        action.OnCollisionEnter(col);
    }
    public virtual void OnCollisionStay2D(Collision2D col)
    {
        action.OnCollisionStay(col);
    }
    public virtual void OnCollisionExit2D(Collision2D col)
    {
        action.OnCollisionExit(col);
    }

    // Start is called before the first frame update
    void Start()
    {
        action = new Idle(this);
    }

    // Update is called once per frame
    void Update()
    {
        action.DoAction();
    }
}
