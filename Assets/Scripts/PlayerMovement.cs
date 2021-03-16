using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerMaxSpeed = 5;
    private Rigidbody2D _rigidbody2D;

    
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var yAxis = Input.GetAxisRaw("Vertical");
        var maxSpeed = playerMaxSpeed + StaticVariables.SpeedBuff;
        
        SharedMethods.ThrustForward(gameObject, _rigidbody2D, -(yAxis * maxSpeed));
        SharedMethods.ClampVelocity(_rigidbody2D, -maxSpeed, maxSpeed);
        
        
        if (!(Camera.main is null))
        {   
            /* rotation with mouse handling */
            var mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position); 
            var angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            angle += 90;
            Transform transform1;
            (transform1 = transform).rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            SharedMethods.EscapeScreen(transform1,transform1.position );
        }
    }
}
