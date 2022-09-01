using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{

    public GameObject confirmPanel;

    public void PressedReset()
    {
        confirmPanel.SetActive(true);
    }

    public void PressedNo()
    {
        confirmPanel.SetActive(false);
    }
}
