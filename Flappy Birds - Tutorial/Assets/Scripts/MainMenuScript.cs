using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadSceneAsync("FlappyBirdsGame");
    }
    public void quiteGame()
    {
        Application.Quit();
    }
}
