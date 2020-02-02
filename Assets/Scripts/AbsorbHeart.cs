using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbHeart : MonoBehaviour
{
    public Animator animator;
    public GameObject heart;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            var player = col.gameObject.GetComponent<Player>();
            player.action = new AbsorbColor(player);
            player.animator.SetTrigger("AbsorbHeart");
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Collider2D>().enabled = false;

            StartCoroutine(DestroyHeart());
            this.animator.SetTrigger("AbsorbHeart");
        }
    }

    IEnumerator DestroyHeart()
    {
        yield return new WaitForSeconds(1f);
        Destroy(heart);
    }
}