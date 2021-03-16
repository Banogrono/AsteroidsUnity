using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
  public class MainMenu : MonoBehaviour
  {
    public void PlayGame()
    {
      StaticVariables.GenocideShot = 0;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  
    public void QuitGame()
    {
      Application.Quit();
    }
  }
}
