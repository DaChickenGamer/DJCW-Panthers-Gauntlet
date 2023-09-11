using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public Transform spawnLocation;
    public Quaternion spawnRotation;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemy,spawnLocation.position,spawnRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
