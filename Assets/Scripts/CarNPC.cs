using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class CarNPC : MonoBehaviour
{

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    public float wordSpeed;

    public AudioSource talkingSound;

    private bool isTyping = false;

    void Start()
    {
        dialogueText.text = "";
        StartCoroutine(Typing("Where do you want to go?"));
    }

    IEnumerator Typing(string dialogue)
    {
        isTyping = true;
        talkingSound.Play();
        foreach(char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        talkingSound.Stop();
        isTyping = false;
        
        if(dialogueText.text != "Where do you want to go?" && dialogueText.text != "So, where do you want to go?")
        {
            isTyping = true;
            yield return new WaitForSeconds(1.2f);
            dialogueText.text = "";
            StartCoroutine(Typing("So, where do you want to go?"));
        }
        
    }

    public void PressedAirportButton()
    {
        if(!isTyping){
            dialogueText.text = "";

            int rand = Random.Range(0, 4);
            string[] dialogues = new string[] {
                "Haha looks like you misclicked!", 
                "I don't think you meant to do that...", 
                "Nah nah",
                "Why do you hate me :|"
                };
            
            StartCoroutine(Typing(dialogues[rand]));
        }
    }
}
