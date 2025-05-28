using System.Collections;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string itemName; 
    private Player player; 

    void Start()
    {
        // Buscar el componente Player en la escena
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " + other.name); // Verificar la colisión
        if (other.CompareTag("Player"))
        {
            Debug.Log("Objeto recogido: " + itemName);

            // Llamar a CollectItem
            player.CollectItem(itemName);

            // Destruir el objeto inmediatamente
            Destroy(gameObject); // Eliminar el objeto
        }
    }

}
