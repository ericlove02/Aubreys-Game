using System;  
using System.IO;  
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject poemObject = null;
    public GameObject uiObject = null;

    public AudioSource collectSound = null;

    public GameObject confirmPanel;
    public AudioSource trashSound;

    public int inventorySize;

    // Start is called before the first frame update
    void Start()
    {
        var list = getInventory();
        inventorySize = list.Count;

        if(uiObject != null){
            // Debug.Log(uiObject.name.Substring(6));
            if(uiObject.tag == "Poem" && !list.Contains(uiObject.name.Substring(6)))
            {
                uiObject.SetActive(false);
            }
            else
            {
                uiObject.SetActive(true);
            }
        }

        if(poemObject != null){
            if(poemObject.tag == "Poem" && !list.Contains(poemObject.name))
            {
                poemObject.SetActive(true);
            }
            else
            {
                poemObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToInventory(string value)
    {
        File.AppendAllText(@"./inventory.txt", value + Environment.NewLine);
    }

    public List<string> getInventory()
    {
        List<string> list = new List<string>();
        if (File.Exists("./inventory.txt"))
        {
            using (var file = new StreamReader("./inventory.txt"))  
            { 
                string line;
                while((line = file.ReadLine()) != null) 
                {  
                    list.Add(line.Trim());
                }
            }
        }
        return list;
    }

    public void ClearInventory()
    {
        System.IO.File.WriteAllText("./inventory.txt", string.Empty);
        trashSound.Play();
        confirmPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var list = getInventory();
        if(poemObject != null && poemObject.tag == "Poem" && other.tag == "Player" && !list.Contains(poemObject.name)) {
            if(collectSound != null){
                collectSound.Play();
            }
            addToInventory(poemObject.name);
            poemObject.SetActive(false);
            uiObject.SetActive(true);
            // Debug.Log(poemObject.name + " added to inventory");
            inventorySize = list.Count;
        }
    }
}
