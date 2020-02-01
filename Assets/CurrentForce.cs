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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Player player = collision.gameObject.GetComponent<Player>();
    //        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

    //        rb.gravityScale = 0;

    //        Debug.Log("oof");

    //        //switch (dir)
    //        //{
    //        //    case Direction.Left:
    //        //        player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 50, ForceMode2D.Impulse);
    //        //        break;
    //        //    case Direction.Right:
    //        //        player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50, ForceMode2D.Impulse);
    //        //        break;
    //        //    case Direction.Up:
    //        //        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50, ForceMode2D.Impulse);
    //        //        break;
    //        //    case Direction.Down:
    //        //        player.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 50, ForceMode2D.Impulse);
    //        //        break;
    //        //}
    //        rb.MovePosition(rb.position + directions[intendedDir] * currentStrength * Time.deltaTime);
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            rb.gravityScale = 0;

            Debug.Log("oof");

            //switch (dir)
            //{
            //    case Direction.Left:
            //        player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 50, ForceMode2D.Impulse);
            //        break;
            //    case Direction.Right:
            //        player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50, ForceMode2D.Impulse);
            //        break;
            //    case Direction.Up:
            //        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50, ForceMode2D.Impulse);
            //        break;
            //    case Direction.Down:
            //        player.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 50, ForceMode2D.Impulse);
            //        break;
            //}
            rb.MovePosition(rb.position + directions[intendedDir] * currentStrength * Time.deltaTime);
        }
    }
}
