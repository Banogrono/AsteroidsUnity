
using UnityEngine;
using Random = System.Random;

public class SpawnExplosion : MonoBehaviour
{
    public GameObject explosion;
    private void OnDestroy()
    {
        SoundHandler.PlayExplosionSound();
        var scale = (float) (2 + new Random().NextDouble());
        explosion.transform.localScale = new Vector3(scale, scale, scale); 
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
    }
}
