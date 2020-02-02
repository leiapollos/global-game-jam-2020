using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthBorder2 : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.adaptCollider = true;
            player.GetComponent<CapsuleCollider2D>().enabled = false;
            player.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
