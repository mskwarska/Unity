using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;


    private void Awake()
    {
        instance = this; //singelton
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audioClip)
    {
        source.PlayOneShot(audioClip);
    }
}
