using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCode : MonoBehaviour
{
    // Update is called once per frame
    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.name == ("Top Wall"))
        {
            transform.Translate(Vector2.down);
        }
        else if (collider.gameObject.name == ("Left Wall"))
        {
            transform.Translate(Vector2.right);
        }
        else if (collider.gameObject.name == ("Right Wall"))
        {
            transform.Translate(Vector2.left);
        }
        else if (collider.gameObject.name == ("Bottom Wall"))
        {
            transform.Translate(Vector2.up);
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == ("Top Wall"))
        {
            transform.Translate(Vector2.down);
        }
        else if (collider.gameObject.name == ("Left Wall"))
        {
            transform.Translate(Vector2.right);
        }
        else if (collider.gameObject.name == ("Right Wall"))
        {
            transform.Translate(Vector2.left);
        }
        else if (collider.gameObject.name == ("Bottom Wall"))
        {
            transform.Translate(Vector2.up);
        }
    }
}
