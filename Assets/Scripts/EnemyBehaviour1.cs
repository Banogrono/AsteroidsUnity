using UnityEngine;

public class EnemyBehaviour1 : MonoBehaviour
{
    public float enemyRotationSpeed = 120f;
    public float enemyMaxSpeed = 3;
    public float enemyRoundsPerMinute = 200;
    //public float enemyRange = 8;
    public float enemyAllowedDegreesOfFreedom = 6;
    public int enemySpread = 4;
    public GameObject projectile;
    private float _cooldownTimeLeft;
    private Transform _player;
    
    private void Start()
    {
        _cooldownTimeLeft = 60 / enemyRoundsPerMinute;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_player == null)
        {   // find player
            var playerObject = GameObject.FindWithTag("Player");
            
            // if player found, make him a target
            if (playerObject != null)
            {
                _player = playerObject.transform;
            }
        }
        
        // if player couldn't be found
        if (_player == null) return;
        
        // getting right rotation
        var direction = _player.position - transform.position;
        direction.Normalize();
        var zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        var desiredRot = Quaternion.Euler( 0, 0, zAngle );
        (transform).rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, enemyRotationSpeed * Time.deltaTime);
        
        // keep right distance with the player
        SharedMethods.KeepWithinDistance(_player, gameObject, 0.4f, 1.4f, enemyMaxSpeed);
        
        /*
         This piece of code checks if player is within range. However, this enemy relays on KeepDistanceWithin-type-behaviour, 
         which renders this pretty much useless. I leave it here, because it might become useful sometime in the future.  
         
         var distance = _player.position - transform.position;
         var absoluteDistance = new Vector3(Mathf.Abs(distance.x), Mathf.Abs(distance.y), 0);
         var withinRange = (absoluteDistance.x <= enemyRange && absoluteDistance.y <= enemyRange);
        */
        
        
        // if player is within range and within acceptable rotation, then shoot
        if (Mathf.Abs(transform.rotation.eulerAngles.z  - desiredRot.eulerAngles.z) <= enemyAllowedDegreesOfFreedom )
        {
            EnemyShoots();
        }
        
    }

    private void EnemyShoots()
    {
        // projectile cooldown
        _cooldownTimeLeft -= Time.deltaTime;
        if (!(_cooldownTimeLeft <= 0)) return;
        
        _cooldownTimeLeft = 60 / enemyRoundsPerMinute;

        // projectile spread
        var projectileSpread = new System.Random().Next(-enemySpread, enemySpread);
        
        // projectile rotation
        var rotation = transform.rotation;
        var z = rotation.eulerAngles.z + projectileSpread;
        var projectileRotation = Quaternion.Euler(0, 0, z);
        var offset = rotation * new Vector3(0, -0.2f, 0);
        
        SoundHandler.PlayShotSound();
        var enemyProjectile = Instantiate(projectile, transform.GetChild(0).position - offset, projectileRotation);
        enemyProjectile.layer = 14;
    }

    private void OnDestroy()
    {
        StaticVariables.Score += 5;
    }
}
