using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Npc1 : MonoBehaviour
{
    public GameObject dialoguePanel; // Reference to the dialogue box GameObject
    public TextMeshProUGUI dialogueText; // Reference to the Text component in the dialogue box
    public string[] dialogue; // Array of dialogue lines
    private int index; // Index of the current dialogue line

    public GameObject continuarBTN;
    public float wordSpeed;
    private bool isPlayerInRange; // Flag to check if the player is in range
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInRange) // Check if the player presses E and is in range
        {
            if (dialoguePanel.activeInHierarchy) // If the dialogue panel is active, hide it
            {
                zeroText(); // Call the method to clear the text and hide the panel
            }
            else // If the dialogue panel is not active, show it and start the dialogue
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing()); // Start the typing coroutine to display the dialogue

            }
        }
        if (dialogueText.text == dialogue[index]) // Check if the current line of dialogue is fully displayed
        {
            continuarBTN.SetActive(true); // Show the continue button
        }
        
    }

    public void zeroText()
    {
        dialogueText.text = ""; // Clear the text in the dialogue box
        index = 0; // Reset the index to start from the first line of dialogue
        dialoguePanel.SetActive(false); // Hide the dialogue panel
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true; // Set the flag to true when the player enters the trigger
        }
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray()) // Loop through each character in the current dialogue line
        {
            dialogueText.text += letter; // Add the character to the text box
            yield return new WaitForSeconds(wordSpeed); // Wait for a short duration before adding the next character
        }
    }

    public void NextLine()
    {
        continuarBTN.SetActive(false); // Hide the continue button
        if (index < dialogue.Length - 1) // Check if there are more lines of dialogue
        {
            index++; // Move to the next line
            dialogueText.text = ""; // Clear the text box
            StartCoroutine(Typing()); // Start the typing coroutine to display the next line
        }
        else // If there are no more lines of dialogue, hide the panel and reset the index
        {
            zeroText(); // Call the method to clear the text and hide the panel
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false; // Set the flag to true when the player enters the trigger
            zeroText(); // Call the method to clear the text and hide the panel
        }
    }
}
