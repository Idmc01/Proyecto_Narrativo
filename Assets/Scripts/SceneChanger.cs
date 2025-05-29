using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string itemName;
    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisi�n detectada con: " + other.name); // Verificar la colisi�n
        if (other.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TalkingtoBigJustice");
        }
    }
}
