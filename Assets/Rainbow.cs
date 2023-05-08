using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    public Material mt;
    public Color32[] colors;
    // Start is called before the first frame update
    void Start()
    {
        mt = transform.GetComponent<MeshRenderer>().material;
        colors = new Color32[7]
        {
            new Color32(255, 0, 0, 255), //red
            new Color32(255, 165, 0, 255), //orange
            new Color32(255, 255, 0, 255), //yellow
            new Color32(0, 255, 0, 255), //green
            new Color32(0, 0, 255, 255), //blue
            new Color32(75, 0, 130, 255), //indigo
            new Color32(238, 130, 238, 255), //violet
        };
        StartCoroutine(Cycle());
    }

    public IEnumerator Cycle()
    {
        int i = 0;
        while (true)
        {
            for (float interpolant = 0f; interpolant < 1f; interpolant += 0.001f)
            {
                mt.color = Color.Lerp(colors[i % 7], colors[(i + 1) % 7], interpolant);
                yield return null;
            }
            i++;
        }
    }
}
