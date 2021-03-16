using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public GameObject smallAsteroid;
    public float asteroidMaxSpeed = 128;
    public float asteroidMinSpeed = 32;
    private Rigidbody2D _rigidbody2D;
    private float _asteroidRotation;
    private readonly System.Random _random = new System.Random();
    private bool _isSpinning;
    private int _rotationSpeed;
    private float _asteroidSize = 1f;
    private bool _isQuitting;
    
    private void Start()
    { 
        // randomize spin
        _isSpinning = _random.Next(0, 3) > 0;
        _rotationSpeed = _random.Next(-3, 3);
        
        // scaling
        var scale = (float) _random.NextDouble() * _asteroidSize;
        gameObject.transform.localScale += new Vector3(scale,scale,scale);
        _asteroidSize = scale;
        
        // movement
        asteroidMaxSpeed *= (2 - scale);
        var speed = (float)(_random.NextDouble() * asteroidMaxSpeed + asteroidMinSpeed);
        _asteroidRotation = _random.Next(0, 360);
        transform.rotation = Quaternion.AngleAxis(_asteroidRotation, Vector3.forward);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(transform.up * speed); // force
    }
    
    // Update is called once per frame
    private void Update()
    {
        var transform1 = transform;
        
        if (_isSpinning)
        {
            var rotation = Quaternion.Euler(0, 0, _asteroidRotation);
            _asteroidRotation += _rotationSpeed;
            transform1.rotation = rotation;
        }
        SharedMethods.EscapeScreen(transform1, transform1.position, 3f);
    }

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }


    private void OnDestroy()
    {
        StaticVariables.Score += 2;
        if (_isQuitting) return; 
        MakeNewAsteroid();
    }

    /// <summary>
    /// Spawns 2 new asteroids each half the size of the original one. The new asteroids can't be smaller than 20% of the size of an old asteroid. 
    /// </summary>
    private void MakeNewAsteroid()
    {
        var scale =  _asteroidSize * 0.5f;
        if (scale < 0.2) return;
        
        smallAsteroid.transform.localScale = new Vector3(scale, scale, scale);
        var position = transform.position;
        Instantiate(smallAsteroid, position, Quaternion.identity);
        Instantiate(smallAsteroid, position, Quaternion.identity);
    }
}
