using UnityEngine;

public class stopTimer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Aseg�rate que el objeto con el temporizador tiene este tag o nombre
        CountdownTimerTMP temporizador = FindObjectOfType<CountdownTimerTMP>();

        if (temporizador != null)
        {
            //temporizador.tiempoInicial = 1000f;
           // Destroy(temporizador);
        }
    }
}
