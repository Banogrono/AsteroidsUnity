using UnityEngine;


namespace UI
{
    public class SettingsMenu : MonoBehaviour
    {
        // private void Start()
        // {
        //     var musicSlider = GameObject.FindWithTag("MusicSlider");
        //     musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        //
        //     var soundSlider = GameObject.FindWithTag("SoundSlider");
        //     soundSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
        //
        //     var inputField = GameObject.FindWithTag("InputField");
        //     inputField.GetComponent<InputField>().text = PlayerPrefs.GetInt("MaxAsteroids", 36).ToString();
        // }

        public void AdjustSound(float newVolume)
        {
            StaticVariables.EffectsVolume = newVolume; 
            PlayerPrefs.SetFloat("EffectsVolume", newVolume);
        }
    
        public void AdjustMusic(float newVolume)
        {
            StaticVariables.MusicVolume = newVolume;
            PlayerPrefs.SetFloat("MusicVolume", newVolume);
        }

        public void SetNewAsteroidNumber(int number)
        {
            StaticVariables.MaxAsteroids = number;
            PlayerPrefs.SetInt("MaxAsteroids", number);
        }

        public void SetDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                case 0: // easy
                    StaticVariables.Difficulty = 0.2f;
                    StaticVariables.PlayerLives = 4;
                    StaticVariables.EnemySpawnCooldown = 5f;
                    StaticVariables.InvulnerabilityTimer = 4f;
                    StaticVariables.MaxAsteroids = 48;
                    StaticVariables.DifficultyLevel = 2;
                    break;
                case 1: // normal
                    StaticVariables.Difficulty = 0.5f;
                    StaticVariables.PlayerLives = 3;
                    StaticVariables.EnemySpawnCooldown = 2f;
                    StaticVariables.InvulnerabilityTimer = 3f;
                    StaticVariables.MaxAsteroids = 96;
                    StaticVariables.DifficultyLevel = 1;
                    break;
                case 2: // hard
                    StaticVariables.Difficulty = 0.95f;
                    StaticVariables.PlayerLives = 2;
                    StaticVariables.EnemySpawnCooldown = 0.5f;
                    StaticVariables.InvulnerabilityTimer = 1f;
                    StaticVariables.MaxAsteroids = 192;
                    StaticVariables.DifficultyLevel = 0;
                    break;
            }
        }
    }
}
