using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLogo : MonoBehaviour
{
    public Image logo;

    // Update is called once per frame
    void Update()
    {
        if(logo.transform.position.x <= -703)
        {
            logo.transform.position = new Vector3(1621, 400, 0);
        }
        logo.transform.position += new Vector3(-0.25f, 0f, 0f);

    }
}
