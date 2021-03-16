using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private static AudioClip _explosionSound1, _explosionSound2, _explosionSound3, _powerUpSound1, _shotSound1;
    private static AudioSource _audioSource;

    private void Start()
    {
        _explosionSound1 = Resources.Load<AudioClip>("Explosion_01");
        _explosionSound2 = Resources.Load<AudioClip>("Explosion_02");
        _explosionSound3 = Resources.Load<AudioClip>("Explosion_03");
        _powerUpSound1  = Resources.Load<AudioClip>("power_up");
        _shotSound1 = Resources.Load<AudioClip>("Shoot_01");
        _audioSource = GetComponent<AudioSource>();
        
        if (_audioSource == null) _audioSource = gameObject.AddComponent<AudioSource>(); 
        
        _audioSource.volume = StaticVariables.EffectsVolume;
    }

    public static void PlayExplosionSound()
    {
        var select = new System.Random().Next(1, 4);
        switch (select)
        {
            case 1:
                if (_explosionSound1 == null) break;
                _audioSource.PlayOneShot(_explosionSound1);
                break;
            case 2:
                if (_explosionSound2 == null) break;
                _audioSource.PlayOneShot(_explosionSound2);
                break;
            case 3:
                if (_explosionSound3 == null) break;
                _audioSource.PlayOneShot(_explosionSound3);
                break;
        }
    }
    
    public static void PlayPowerUpSound()
    {
        _audioSource.PlayOneShot(_powerUpSound1);
    }
    
    public static void PlayShotSound()
    {
        _audioSource.PlayOneShot(_shotSound1);
    }
}
