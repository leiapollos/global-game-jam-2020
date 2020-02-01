using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    public List<GameObject> sprites;
    public GameObject solidFloorWater;
    
    public void enableSprite(string name)
    {
        foreach(GameObject s in sprites)
        {
            if(s.tag == name)
            {
                s.SetActive(true);
            }
        }
    }

    public void enableWater()
    {
        Destroy(solidFloorWater);
        enableSprite("Water");
        enableSprite("WaterSurface");
    }

}
