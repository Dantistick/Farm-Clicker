using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void ChangScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

}