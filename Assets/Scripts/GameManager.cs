using UnityEngine;
using System.Collections.Generic;  

public class GameManager : MonoBehaviour
{

    public List<string> collectedItems = new List<string>();


    public static GameManager instance;

    void Awake()
    {
        // Asegurarse de que solo haya una instancia del GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Agregar un objeto a la lista de objetos recogidos
    public void AddCollectedItem(string itemName)
    {
        if (!collectedItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
        }
    }

    // Comprobar si un objeto ha sido recogido
    public bool HasCollectedItem(string itemName)
    {
        return collectedItems.Contains(itemName);
    }
}
