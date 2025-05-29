using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    public string[] dialogue;
    public GameObject tilemapPuertas; // Arrastra aquí en el inspector el Tilemap "Puertas"
    public GameObject npcExtra;       // Normalmente este mismo GameObject (puedes usar this.gameObject)
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager.Instance.StartDialogue(dialogue, this);
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
            DialogueManager.Instance.EndDialogue();
        }
    }

    // Método que llama DialogueManager cuando termina el diálogo
    public void OnDialogueEnd()
    {
        Debug.Log($"OnDialogueEnd llamado en {gameObject.name}");

        if (tilemapPuertas != null)
        {
            Debug.Log("Intentando desactivar tilemapPuertas...");
            tilemapPuertas.SetActive(false);
            Debug.Log("tilemapPuertas desactivado.");
        }
        else
        {
            Debug.LogWarning("tilemapPuertas es null");
        }

        if (npcExtra != null)
        {
            Debug.Log("Desactivando npcExtra...");
            npcExtra.SetActive(false);
            Debug.Log("npcExtra desactivado.");
        }
        else
        {
            Debug.LogWarning("npcExtra es null");
        }
    }
    }

