using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float lifetime = 4f;
    
    // Update is called once per frame
    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
