using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName;

    public void NavigateTo()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
