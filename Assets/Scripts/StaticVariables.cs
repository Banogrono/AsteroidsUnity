
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    // general settings
    public static int Score = 0;
    public static int PlayerLives = 3;
    public static float SpeedBuff = 0f;
    public static int GenocideShot = 0;
    
    // sound control
    public static float EffectsVolume = 0.7f;
    public static float MusicVolume = 0.7f;
  
    // difficulty control
    public static float EnemySpawnCooldown = 10f;
    public static int MaxAsteroids = 36;
    public static float Difficulty = 0.1f;
    public static int DifficultyLevel = 1;
  
    // other, less important settings
    public static float RespawnTimer = 2.5f;
    public static float InvulnerabilityTimer = 5f;


    private void Start()
    {
    // sound control
    EffectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0.7f);
     MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
  
    // difficulty control
    EnemySpawnCooldown = 10f;
     MaxAsteroids = PlayerPrefs.GetInt("MaxAsteroids", 36);
   Difficulty = PlayerPrefs.GetFloat("Difficulty", 0.1f);
  
    // other, less important settings
    RespawnTimer = PlayerPrefs.GetFloat("RespawnTimer", 2.5f);
     InvulnerabilityTimer = PlayerPrefs.GetFloat("InvulnerabilityTimer", 5f);
    }
}
