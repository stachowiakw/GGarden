using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfterTime;

    void Start()
    {
        if (autoLoadNextLevelAfterTime <= 0)
        {
            Debug.Log("Level auto load disabled");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfterTime);
        }
    }

    public void LevelChange(string name)
    {
        Debug.Log("no elo " + name);
        SceneManager.LoadScene(name);

    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
        
    public void RequestQuit()
	{
		Debug.Log("qqqqqquit!");
		Application.Quit();
	}

}
