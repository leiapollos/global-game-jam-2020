using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    public List<SpriteRenderer> sprites;
    
    public void enableSprite(string name)
    {
        foreach(SpriteRenderer s in sprites)
        {
            if(s.name == name)
            {
                s.enabled = true;
            }
        }
    }

}
