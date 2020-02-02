using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickApple : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            var player = col.gameObject.GetComponent<Player>();
            player.scenery.enableGreen();
            player.action = new AbsorbColor(player);
            player.animator.SetTrigger("PickApple");
            player.transform.position = new Vector3(130.4f, -10.16f, 0);
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.animator.SetTrigger("PickApple");
            this.GetComponent<Collider2D>().enabled = false;
        }
    }
}
