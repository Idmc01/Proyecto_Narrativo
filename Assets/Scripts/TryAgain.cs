using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public string nombreEscenaDestino;

    public void CargarEscena()
    {
        SceneManager.LoadScene(1);
    }
}
