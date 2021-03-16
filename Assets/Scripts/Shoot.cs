using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public float roundsPerMinute = 600f;
    public int spread = 3;
    private float _cooldownTimeLeft;
    
    // Start is called before the first frame update
    private void Start()
    {
        _cooldownTimeLeft = 60 / roundsPerMinute;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton("Fire2") && StaticVariables.GenocideShot >= 1)
        {
            StaticVariables.GenocideShot--;
            SharedMethods.KillEverythingExceptPlayer();
        }
        
        // projectile cooldown
        _cooldownTimeLeft -= Time.deltaTime;
        if (!Input.GetButton("Fire1") || !(_cooldownTimeLeft <= 0)) return;
        _cooldownTimeLeft = 60 / roundsPerMinute;

        // projectile spread
        var projectileSpread = new System.Random().Next(-spread, spread);
        
        // projectile rotation
        var rotation = transform.rotation;
        var z = rotation.eulerAngles.z + 180 + projectileSpread;
        var projectileRotation = Quaternion.Euler(0, 0, z);
        var offset = rotation * new Vector3(0, 0.15f, 0);
        
        SoundHandler.PlayShotSound();
        Instantiate(projectile, transform.GetChild(1).position - offset, projectileRotation);
    }
}
