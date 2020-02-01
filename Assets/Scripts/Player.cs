﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerAction action;
    public float RunVelocity = 0.8f;
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
