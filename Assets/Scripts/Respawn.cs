using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    private GameObject _playerInstance;
    private float _respawnTimer = StaticVariables.RespawnTimer;
    public float invulnerabilityTimer = StaticVariables.InvulnerabilityTimer;
    private bool _isFreshlyRespawned;
    private int _homeLayer;
    
    private void Start()
    {
        _homeLayer = 9; // player layer
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isFreshlyRespawned)
        {   
            invulnerabilityTimer -= Time.deltaTime;
            if (invulnerabilityTimer <= 0)
            {
                _playerInstance.layer = _homeLayer;
                _isFreshlyRespawned = false;
                invulnerabilityTimer = 5f;
            }
        }
        
        if (_playerInstance != null) return;
        _respawnTimer -= Time.deltaTime;
        
        if (!(_respawnTimer <= 0)) return;
        if (StaticVariables.PlayerLives > 0)
        {
            Spawner();
        }
    }
    
    private void Spawner() 
    {
        _respawnTimer = 3f;
        _playerInstance = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        _playerInstance.name = "PlayerShip";
        _playerInstance.layer = 13;
        _isFreshlyRespawned = true; 
        StaticVariables.PlayerLives--;
    }
}
