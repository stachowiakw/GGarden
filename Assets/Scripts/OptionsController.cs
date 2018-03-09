using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider, difficultySlider;
    public LevelManager levelManager;
    public string levelToGetBack;

    private MusicManager musicManager;

    // Use this for initialization
    void Start() {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        Debug.Log(musicManager);
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update() {
        if (musicManager) { musicManager.ChangeVolume(volumeSlider.value); }
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        levelManager.LevelChange(levelToGetBack);
    }

    public void SetDefaults()
    {
        difficultySlider.value = 2f;
        volumeSlider.value = 0.5f;
    }
}
