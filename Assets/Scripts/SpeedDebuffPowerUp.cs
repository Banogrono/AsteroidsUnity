using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDebuffPowerUp : MonoBehaviour
{
    public float powerUpTimer = 15f;
    private bool _hasPlayerCollided;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Contains("Player")) return;
        
        SoundHandler.PlayPowerUpSound();
        _hasPlayerCollided = true;
        gameObject.transform.localScale = new Vector3(0, 0, 0); // make power up disappear
        StaticVariables.SpeedBuff -= 4;
    }

    private void Update()
    {
        if (!_hasPlayerCollided) return;
        powerUpTimer -= Time.deltaTime;
        if (!(powerUpTimer <= 0)) return;
        StaticVariables.SpeedBuff += 4;
        Destroy(gameObject);
    }
}
