using UnityEngine;

public class GenocidePowerUp : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Contains("Player")) return;
        
        SoundHandler.PlayPowerUpSound();
        StaticVariables.GenocideShot++;
        Destroy(gameObject);
    }
}
