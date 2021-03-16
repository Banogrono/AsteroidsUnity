using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        public Text scoreLabel;
    
        
        // Update is called once per frame
        private void Update()
        {
            scoreLabel.text = "Score: " + StaticVariables.Score;

            if (StaticVariables.Score > PlayerPrefs.GetInt("Score", 0))
            {
                PlayerPrefs.SetInt("Score", StaticVariables.Score);  
                SharedMethods.NewHighScore = true;
            }
        }
    }
}
