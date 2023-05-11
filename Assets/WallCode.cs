using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCode : MonoBehaviour
{
    int WallVolcity = 2;
    Rigidbody2D rb;
    public void Start()
    {
        rb=GetComponent<Rigidbody2D>(); 
    }
    // Update is called once per frame
    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.name == ("Top Wall"))
        {
            rb.velocity= new Vector2(rb.velocity.x,-WallVolcity);
        }
        else if (collider.gameObject.name == ("Left Wall"))
        {
            rb.velocity = new Vector2(WallVolcity, rb.velocity.y);
        }
        else if (collider.gameObject.name == ("Right Wall"))
        {
            rb.velocity = new Vector2(-WallVolcity, rb.velocity.y);
        }
        else if (collider.gameObject.name == ("Bottom Wall"))
        {
            rb.velocity = new Vector2(rb.velocity.x,WallVolcity);
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == ("Top Wall") || collider.gameObject.name == ("Red Goal Post") || collider.gameObject.name == ("Blue Goal Post 2"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -WallVolcity);
        }
        else if (collider.gameObject.name == ("Left Wall"))
        {
            rb.velocity = new Vector2(WallVolcity, rb.velocity.y);
        }
        else if (collider.gameObject.name == ("Right Wall"))
        {
            rb.velocity = new Vector2(-WallVolcity, rb.velocity.y);
        }
        else if (collider.gameObject.name == ("Bottom Wallaassdad") || collider.gameObject.name == ("Red Goal Post 2") || collider.gameObject.name == ("Blue Goal Post"))
        {
            rb.velocity = new Vector2(rb.velocity.x, WallVolcity);
        }
    }
}
