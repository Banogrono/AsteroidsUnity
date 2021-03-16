using UnityEngine;

namespace UI
{
    public class GameOverDisplay : MonoBehaviour
    {
        private Vector3 _oldScale;

        private bool _gameMenuEnabled = true;
        
        // Start is called before the first frame update
        private void Start()
        {
            ResumeGame();
            var o = gameObject;
            _oldScale = o.gameObject.transform.localScale;
            o.transform.localScale = new Vector3(0, 0, 0);
        }

        // Update is called once per frame
        private void Update()
        {
            if (StaticVariables.PlayerLives == 0 && GameObject.FindWithTag("Player") == null)
            {
                gameObject.transform.localScale = _oldScale;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _gameMenuEnabled = !_gameMenuEnabled;
                if (_gameMenuEnabled)
                {
                    gameObject.transform.localScale = new Vector3(0, 0, 0);
                    ResumeGame();
                }
                else
                {
                    gameObject.transform.localScale = _oldScale;
                    PauseGame();
                }
            }
        }
        
        
        private static void PauseGame ()
        {
            Time.timeScale = 0;
        }

        private static void ResumeGame ()
        {
            Time.timeScale = 1;
        }
    }
}
