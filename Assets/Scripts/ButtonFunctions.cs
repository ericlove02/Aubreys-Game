using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public AudioSource sounds;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void HoverSound()
    {
        sounds.PlayOneShot(hoverSound);
    }
    public void ClickSound()
    {
        sounds.PlayOneShot(clickSound);
    }
}
