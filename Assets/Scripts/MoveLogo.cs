using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLogo : MonoBehaviour
{
    public Image logo;

    private float y;

    void Start() {
        y = this.transform.position.y;
    }

    void Update()
    {
        if(logo.transform.position.x <= -1000)
        {
            logo.transform.position = new Vector3(4000, y, 0);
        }
        logo.transform.position += new Vector3(-2f, 0f, 0f);

    }
}
