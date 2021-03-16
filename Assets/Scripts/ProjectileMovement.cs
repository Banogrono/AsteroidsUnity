using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 10;

    // Update is called once per frame
    private void Update()
    {
        var transform1 = transform;
        var position = transform1.position;
        var velocity = new Vector3(0, Time.deltaTime * speed, 0);
        
        position += transform1.rotation * velocity;
        transform1.position = position;
    }
}
