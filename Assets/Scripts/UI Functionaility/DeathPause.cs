using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1.0f;
    }
    public void Death()
    {
        Time.timeScale = 0.0f;
    }
}
