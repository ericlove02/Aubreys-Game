using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignTrigger : MonoBehaviour
{

    public GameObject signPanel;
    public TextMeshProUGUI signText;
    public string text;

    public GameObject keyMessage;

    public bool playerIsClose;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose && !signPanel.activeInHierarchy)
        {
            signPanel.SetActive(true);
            signText.text = text;
        }
        else if(Input.GetKeyDown(KeyCode.E) && playerIsClose && signPanel.activeInHierarchy){
            signPanel.SetActive(false);
            signText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
            keyMessage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            keyMessage.SetActive(false);
            signPanel.SetActive(false);
            playerIsClose = false;
            signText.text = "";
        }
    }
}
