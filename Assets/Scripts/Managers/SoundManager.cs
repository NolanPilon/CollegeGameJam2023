using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;


    [SerializeField]
    private AudioSource soundEffect;
    [SerializeField]
    private AudioSource music;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;    
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlaySound(AudioClip clip)
    {
        soundEffect.PlayOneShot(clip);
    }

   public void ToggleMusic()
    {
        music.mute = !music.mute;
    }

}
