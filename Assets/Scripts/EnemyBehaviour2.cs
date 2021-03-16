using UnityEngine;

public class EnemyBehaviour2 : MonoBehaviour
{
     public float enemyRotationSpeed = 75f;
    public float enemyMaxSpeed = 5;
    //public float enemyRange = 8;

    private Transform _player;
    
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
        
        SharedMethods.ThrustForward(gameObject, GetComponent<Rigidbody2D>(), enemyMaxSpeed);
        
    }
    
    private void OnDestroy()
    {
        StaticVariables.Score += 3;
    }
}
