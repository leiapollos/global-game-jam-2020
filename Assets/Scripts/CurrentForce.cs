using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentForce : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    };

    static private Dictionary<Direction, Vector2> directions = new Dictionary<Direction, Vector2> {
        { Direction.Down, Vector2.down },
        { Direction.Up, Vector2.up },
        { Direction.Left, Vector2.left },
        { Direction.Right, Vector2.right },
    };

    public Direction intendedDir;
    public float currentStrength;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            player.adaptCollider = false;
            player.GetComponent<CapsuleCollider2D>().enabled = false;
            player.GetComponent<CircleCollider2D>().enabled = true;


            rb.gravityScale = 0;

            Debug.Log("oof");
            rb.MovePosition(rb.position + directions[intendedDir] * currentStrength * Time.deltaTime);
        }
    }
}
