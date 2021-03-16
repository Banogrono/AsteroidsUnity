using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private GameObject _player;
    public GameObject shield; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Contains("Player")) return;
        
        SoundHandler.PlayPowerUpSound();
        _player = GameObject.FindWithTag("Player"); // find the player
        Instantiate(shield, _player.transform.position, Quaternion.identity); // spawn shield on the player
        Destroy(gameObject);
    }
}
