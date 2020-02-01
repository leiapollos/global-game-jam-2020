using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthBorder : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.adaptCollider = true;
            player.GetComponent<BoxCollider2D>().enabled = true;
            player.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
