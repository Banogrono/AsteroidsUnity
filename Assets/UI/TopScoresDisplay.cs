using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TopScoresDisplay : MonoBehaviour
    {
    
        public Text topScoreLabel;
        
        // Update is called once per frame
        private void Update()
        {
            if (StaticVariables.PlayerLives != 0 || GameObject.FindWithTag("Player") != null) return;
            if (SharedMethods.NewHighScore)
            {
                topScoreLabel.color = Color.yellow;
                topScoreLabel.text = "High Score: " + PlayerPrefs.GetInt("Score", 0) + " - New High Score!";
                SharedMethods.NewHighScore = false;
            }
            else
            {
                topScoreLabel.color = Color.white;
                topScoreLabel.text = "High Score: " + PlayerPrefs.GetInt("Score", 0);
            }


        }
    }
}
 