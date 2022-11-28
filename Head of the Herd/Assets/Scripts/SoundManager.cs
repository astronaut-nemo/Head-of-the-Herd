using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if(instance==null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        musicSource.Play();
    }

    // References
    [SerializeField] private AudioSource musicSource, effectsSource;

    // Update is called once per frame
    void Update()
    {
        
    }

    // Play sound effects
    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

    // Change volume
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
