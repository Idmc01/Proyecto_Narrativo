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
}
