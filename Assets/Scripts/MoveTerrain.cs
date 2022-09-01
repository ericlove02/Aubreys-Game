using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTerrain : MonoBehaviour
{
    public Image terrain;

    // Update is called once per frame
    void Update()
    {
        if(terrain.transform.position.x <= -943)
        {
            terrain.transform.position = new Vector3(1381, 445, 0);
        }
        terrain.transform.position += new Vector3(-0.25f, 0f, 0f);

    }
}