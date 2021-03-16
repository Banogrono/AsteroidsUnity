using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameManager : MonoBehaviour
    {
  
        public void PlayAgain()
        {
           
            SharedMethods.FindLowestScoreAndReplace(StaticVariables.Score);
            var currentSceneName = SceneManager.GetActiveScene().name;
           
            SceneManager.LoadScene(currentSceneName);
            StaticVariables.PlayerLives = 3;
            StaticVariables.Score = 0;
        }

        public void BackToGameMenu()
        {
            StaticVariables.PlayerLives = 3;
            StaticVariables.Score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        } 

    }
}
