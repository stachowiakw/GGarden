using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    public int score;
    public Text ScoreText;
    private string ScoreString = "SCORE: ";

	
	// Update is called once per frame
	void Update () {
        ScoreText.text = ScoreString + score;
	}
}
