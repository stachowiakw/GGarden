using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource musicManagerAudioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
    }

    void Start()
    {
        musicManagerAudioSource = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level)
    {
        if (levelMusicChangeArray[level])
        {
            AudioClip thisLevelMusic = levelMusicChangeArray[level];
            Debug.Log("Playing Clip: " + thisLevelMusic);
            if (thisLevelMusic)
            {
                musicManagerAudioSource.clip = thisLevelMusic; // if there is any clip attached to on the field corresponding with the level
                musicManagerAudioSource.Play();
            }
        }
    }

    public void ChangeVolume(float newVolume)
    {
        musicManagerAudioSource.volume = newVolume;
    }
}
