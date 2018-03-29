using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {
    public float GameTime = 10;
    private Slider GameTimeSlider;
    private AudioSource audioSource;
    private LevelManager levelManager;
    private GameObject winLabel;
    private bool WinningEnd = false;
    private GameObject[] entities;

    // Use this for initialization
    void Start () {
        GameTimeSlider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("WinLabel");
        winLabel.SetActive(false);
        GameTimeSlider.maxValue = GameTime;
        GameTimeSlider.value = GameTime;
	}
	
	// Update is called once per frame
	void Update () {
        GameTimeSlider.value -= 1 * Time.deltaTime;
        if (GameTimeSlider.value <= 0 && !WinningEnd)
        {
            WinningEnd = true;
            Winning();
        }
	}

    void Winning()
    {
        DestroyAllTaggedObjects();
        winLabel.SetActive(true);
        audioSource.Play();
        Invoke("LoadNextLevelAfterWin", 5);
    }
    void LoadNextLevelAfterWin() { levelManager.LevelChange("03a Win"); }

    void DestroyAllTaggedObjects()
    {
        entities = GameObject.FindGameObjectsWithTag("entities");
        print(entities.Length);
        foreach (GameObject entity in entities)
        { Destroy(entity); }
    }
}
