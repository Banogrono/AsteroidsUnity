
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] asteroidArray = new GameObject[4];
    //public List<GameObject> asteroidList;
    private float _enemySpawnCooldown = StaticVariables.EnemySpawnCooldown;
    public float spawnDistance = 15f;
    private readonly int _maxAsteroids = StaticVariables.MaxAsteroids;
    private float _difficulty = StaticVariables.Difficulty;
    private float _temp;

    // Start is called before the first frame update
    private void Start()
    {
        _temp = _enemySpawnCooldown;
        _difficulty = Mathf.Clamp(_difficulty, 0.01f, 0.95f);
    }

    // Update is called once per frame
    private void Update()
    {
        // clearing scene after player dies
        if (GameObject.FindWithTag("Player") == null && StaticVariables.PlayerLives <= 0)
        {
           SharedMethods.KillEverythingExceptPlayer();
        }
        
        
        if (GameObject.FindWithTag("Player") == null) return;
        
        _enemySpawnCooldown -= Time.deltaTime;

        if (_enemySpawnCooldown <= 0 && SharedMethods.AsteroidNumber <= _maxAsteroids)
        {
            SpawnAsteroid();
            _enemySpawnCooldown = _temp * (1 - _difficulty);

            if (_enemySpawnCooldown <= 0.5f)
            {
                _enemySpawnCooldown = 0.5f + StaticVariables.DifficultyLevel;
            }
        }
    }

    private void SpawnAsteroid()
    {
        // select random asteroid from an array
        var selectRandom = new System.Random().Next(0, (asteroidArray.Length - 1));
        SpawnObject(asteroidArray[selectRandom]);
        SharedMethods.AsteroidNumber++;
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        // spawn on a sphere in radius 
        var spawnPosition = Random.onUnitSphere;
        spawnPosition.z = 0; // 2D game, no need to spawn stuff in z axis
        spawnPosition = spawnPosition.normalized * spawnDistance;

        Instantiate(objectToSpawn, transform.position + spawnPosition, Quaternion.identity);
    }
}
