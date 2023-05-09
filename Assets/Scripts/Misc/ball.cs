using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ball : MonoBehaviour
{
    private float movedelay;
    public Rigidbody2D rb;
    public int x=2, y=2;
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
            if (y == 0 || y >= 50 || y <= -50)
            {
                y = 2;
            }
            if (x == 0 || x >= 50 || x <= -50)
            {
                x = 2;
            }
            x = Random.Range(x*y, x*y);
            y = Random.Range(y*x, y*x);
            
            rb.velocity = new Vector2(x, y);
            movedelay = 1;
        }
        if (y < 0)
        {
            y = -y;
        }
        if (x < 0)
        {
            x = -x;
        }
        rb.rotation += Time.deltaTime*math.pow(math.pow(x*y,2), 2)+(Time.deltaTime*Time.deltaTime*rb.rotation);
        if (rb.rotation > 900000||rb.rotation<-900000)
        {
            rb.rotation = 0;
        }
    }
}
