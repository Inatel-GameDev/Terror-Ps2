using UnityEngine;

public class AudioManager: MonoBehaviour
{
    
    public AudioSource audioSource;
    
    public void playSound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}

    
