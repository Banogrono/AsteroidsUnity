using UnityEngine;

public class SuperGunPowerup : MonoBehaviour
{
    public float powerUpTimer = 20f;
    
    private GameObject _player;
    private Shoot _playerShoot;
    private bool _hasPlayerCollided;
    private float _oldFireRate;
    private int _oldSpread;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.name.Contains("Player")) return;
        
        SoundHandler.PlayPowerUpSound();
        _hasPlayerCollided = true;
        gameObject.transform.localScale = new Vector3(0, 0, 0); // make power up disappear
        _player = GameObject.FindWithTag("Player"); // find the player
        _playerShoot = _player.GetComponent<Shoot>(); // get the shoot component
        _oldFireRate = _playerShoot.roundsPerMinute; // save old fire rate
        _oldSpread = _playerShoot.spread; // save old spread
        
        _playerShoot.roundsPerMinute *= 3; // set new fire rate
        _playerShoot.spread *= 2; 
    }

    private void Update()
    {
        if (!_hasPlayerCollided) return;

        powerUpTimer -= Time.deltaTime;

        if (!(powerUpTimer <= 0)) return;
        _playerShoot.roundsPerMinute = _oldFireRate;
        _playerShoot.spread = _oldSpread;
        Destroy(gameObject);
    }
}
