using System.Xml.Serialization;
using UnityEngine;

public class UIControllerTitle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        Debug.Log("Play");
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
    public void Credits()
    {
        Debug.Log("Credits");
        // Load the credits scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("CreditsScene");
    }
    public void BackToMenu()
    {
        Debug.Log("Back to Menu");
        // Load the title scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void SecondScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene2");
    }
    public void carScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PoliceCar");
    }
    public void cell1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CellScene");
    }
    public void cell2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CellScene2");
    }
    public void final()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CellScene");//Cambiar a la escena final
    }
    public void salida()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Salida");
    }
    public void salida1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Salida1");
    }
    public void salida2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Salida2");
    }
    public void salida3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Salida3");
    }
    public void salida4()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Salida4");
    }
    public void salida5()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Salida5");
    }
    public void salida6()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Salida6");
    }
    public void salida7()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Salida7");
    }
    public void FMalo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FinalMalo");
    }
}
