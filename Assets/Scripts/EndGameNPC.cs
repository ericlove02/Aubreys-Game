using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameNPC : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject keyMessage;

    public float wordSpeed;
    public bool playerIsClose;

    public AudioSource talkingSound;

    private bool isTyping = false;

    public GameObject player;
    public GameObject thisNpc;
    public GameObject otherNpc;

    void Start()
    {
        if(player.GetComponent<PlayerInventory>().inventorySize >= 8)
        {
            thisNpc.SetActive(true);
            otherNpc.SetActive(false);
        }
        else
        {
            thisNpc.SetActive(false);
            otherNpc.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose && !isTyping)
        {
            if(dialoguePanel.activeInHierarchy)
            {
                NextLine();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        isTyping = true;
        talkingSound.Play();
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        talkingSound.Stop();
        isTyping = false;
    }

    public void NextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
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
            playerIsClose = false;
            zeroText();
        }
    }
}
