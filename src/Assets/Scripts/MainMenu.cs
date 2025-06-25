using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Range");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
