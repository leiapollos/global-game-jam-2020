using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    public List<GameObject> sprites;
    public List<GameObject> solidFloorWater;
    public List<GameObject> solidGreen;

    public void enableSprite(string name)
    {
        foreach (GameObject s in sprites)
        {
            if (s.tag == name)
            {
                s.SetActive(true);
            }
        }
    }

    public void enableWater()
    {
        Debug.Log("wwwww");
        foreach (GameObject g in solidFloorWater) g.SetActive(false);
        enableSprite("WaterSegment");
    }

    public void enableGreen()
    {
        foreach (GameObject g in solidGreen) g.SetActive(false);
        enableSprite("GreenNew");
    }
}
