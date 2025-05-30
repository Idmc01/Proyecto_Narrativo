using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimerTMP : MonoBehaviour
{
    public float tiempoInicial = 180f; 
    public string nombreEscenaDestino = "17";
    public TMP_Text textoUI; 

    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    void Update()
    {
        if (tiempoRestante > 0f)
        {
            tiempoRestante -= Time.deltaTime;

            if (textoUI != null)
                textoUI.text = FormatearTiempo(tiempoRestante);

            if (tiempoRestante <= 0f)
            {
                tiempoRestante = 0f;
                CambiarEscena();
            }
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(nombreEscenaDestino);
    }

    string FormatearTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        return string.Format(" Escapa antes de: {0:00}:{1:00}", minutos, segundos);
    }
}
