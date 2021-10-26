using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGM : MonoBehaviour
{
    public static GameBGM instance;

    public AudioClip deathClip;
    public AudioSource deathSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayDeathClip()
    {
        if(deathSource == null)
        {
            deathSource = gameObject.AddComponent<AudioSource>();
            deathSource.playOnAwake = false;
        }

        deathSource.clip = deathClip;
        deathSource.Play();
    }
}
