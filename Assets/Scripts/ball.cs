using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    
    private float movedelay;
    public Rigidbody2D rb;
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
            int x = Random.Range(-10, 10);
            int y = Random.Range(-10, 10);

            rb.velocity = new Vector2(x, y);
            movedelay = 1;
        }
    }
}
