using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        SceneManager.LoadSceneAsync("Level");
    }
    public void Disclaimer()
    {
        SceneManager.LoadSceneAsync("Disclaimer");
    }
    public void Retour()
    {
        SceneManager.LoadSceneAsync("Main_Menu");
    }
}
