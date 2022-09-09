using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTerrain : MonoBehaviour
{
    public Image terrain;

    private float y;
    private float width;

    private RectTransform rt;

    void Start() {
        y = this.transform.position.y;
        rt = GetComponent<RectTransform>();
        width = rt.sizeDelta.x;
    }

    void Update()
    {
        if(terrain.transform.position.x <= -width)
        {
            terrain.transform.position = new Vector3(width*3, y, 0);
        }
        terrain.transform.position += new Vector3(-2f, 0f, 0f);

    }
}
