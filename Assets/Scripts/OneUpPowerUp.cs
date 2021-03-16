using UnityEngine;

public class OneUpPowerUp : MonoBehaviour
{

    private GameObject _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Contains("Player")) return;
        
        SoundHandler.PlayPowerUpSound();
        StaticVariables.PlayerLives++; // increment player's lives 
        Destroy(gameObject);
    }
}
