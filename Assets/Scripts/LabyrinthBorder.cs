using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthBorder : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            //player.adaptCollider = true;
            player.GetComponent<CapsuleCollider2D>().enabled = true;
            player.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
