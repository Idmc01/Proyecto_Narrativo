using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeTimer : MonoBehaviour
{
    public float tiempoInicial = 300f; // 5 minutos
    public TMP_Text textoUI; // Asigna un Text opcional en el Inspector

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
        SceneManager.LoadScene(0);
    }

    string FormatearTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        return string.Format("Escape antes de: {0:00}:{1:00}", minutos, segundos);
    }
}
