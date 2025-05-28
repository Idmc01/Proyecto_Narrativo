using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Npc1 : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;

    public GameObject nameDialoguePanel;
    public TextMeshProUGUI nameDialogueText;
    public string[] nameDialogue;

    public GameObject continuarBTN;
    public float wordSpeed = 0.05f;

    private int index = 0;
    private bool isPlayerInRange;
    private Coroutine typingCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                EndDialogue();
            }
            else
            {
                StartDialogue();
            }
        }

        if (dialoguePanel.activeInHierarchy && dialogueText.text == dialogue[index])
        {
            continuarBTN.SetActive(true);
        }
    }

    void StartDialogue()
    {
        // Reinicia el índice cada vez que se inicia el diálogo
        index = 0;
        dialoguePanel.SetActive(true);
        dialogueText.text = "";
        continuarBTN.SetActive(false);
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(Typing());
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        if (nameDialoguePanel != null) nameDialoguePanel.SetActive(false);
        if (nameDialogueText != null) nameDialogueText.text = "";
        dialogueText.text = "";
        continuarBTN.SetActive(false);
        // No es necesario reiniciar el índice aquí, ya que se reinicia en StartDialogue
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
    }

    public void NextLine()
    {
        continuarBTN.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            if (typingCoroutine != null) StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine(Typing());
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator Typing()
    {
        dialogueText.text = "";
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void ShowNameDialogue(int nameIndex)
    {
        if (nameDialoguePanel != null && nameDialogueText != null && nameDialogue.Length > nameIndex)
        {
            nameDialoguePanel.SetActive(true);
            nameDialogueText.text = nameDialogue[nameIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            EndDialogue();
        }
    }
}
