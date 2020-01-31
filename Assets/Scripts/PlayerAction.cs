using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAction
{
    protected Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void DoAction() { }
}
