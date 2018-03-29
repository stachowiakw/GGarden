using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {
    public static GameObject SelectedPrefab;
    public GameObject SpriteHolder;
    private SpriteRenderer ButtonSprite;
    private Button[] ButtonArray;
    public GameObject ButtonPrefab;
    private Text CostIndicator;

	// Use this for initialization
	void Start () {
        CostIndicator = GetComponentInChildren<Text>();
        CostIndicator.text = ButtonPrefab.GetComponent<Defender>().defenderCost.ToString();
        ButtonSprite = SpriteHolder.GetComponent<SpriteRenderer>();
        ButtonSprite.color = new Vector4(0, 0, 0, 255);
        ButtonArray = FindObjectsOfType<Button>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        foreach (Button SomeButtonInArray in ButtonArray)
        { SomeButtonInArray.ButtonSprite.color = new Vector4(0, 0, 0, 255); }

        ButtonSprite.color = new Vector4(255,255,255,255);
        SelectedPrefab = ButtonPrefab;
        //print(SelectedPrefab);
    }
}
