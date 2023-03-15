using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private float movedelay;
    public Rigidbody2D rb;
    int x, y;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movedelay > 0)movedelay-=Time.deltaTime;
        if (movedelay <= 0)
        {
            x = Random.Range(-10, 10);
            y = Random.Range(-10, 10);

            rb.velocity = new Vector2(x, y);
            movedelay = 1;
        }

        rb.rotation += Time.deltaTime*(x + y)*4;
    }
}
