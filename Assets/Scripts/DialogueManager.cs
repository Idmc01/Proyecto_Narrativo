using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button continuarBTN;
    public float wordSpeed = 0.05f;

    private string[] dialogueLines;
    private int currentIndex = 0;
    private Coroutine typingCoroutine;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        continuarBTN.onClick.AddListener(NextLine);
        dialoguePanel.SetActive(false);
        continuarBTN.gameObject.SetActive(false);
    }

    public void StartDialogue(string[] lines)
    {
        dialogueLines = lines;
        currentIndex = 0;
        dialoguePanel.SetActive(true);
        continuarBTN.gameObject.SetActive(false);

        if (typingCoroutine != null) StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        continuarBTN.gameObject.SetActive(false);

        if (currentIndex < dialogueLines.Length - 1)
        {
            currentIndex++;
            if (typingCoroutine != null) StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        dialogueText.text = "";
        foreach (char letter in dialogueLines[currentIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        continuarBTN.gameObject.SetActive(true);
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        continuarBTN.gameObject.SetActive(false);
    }
}

