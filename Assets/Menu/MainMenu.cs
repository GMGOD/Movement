using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayeGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMenuInput(bool menuInput)
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
