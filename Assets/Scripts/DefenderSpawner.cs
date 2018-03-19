﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myGameCamera;
    private GameObject DefenderParent;

    // Use this for initialization
    void Start () {
        myGameCamera = GameObject.FindObjectOfType<Camera>();

        DefenderParent = GameObject.Find("Defenders");
        if (!DefenderParent)
        {
            DefenderParent = new GameObject("Defenders");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        print(SnapToGrid(CalculateRawWorldPointOfMouseClick()));
        GameObject DefenderSpawned = Instantiate(Button.SelectedPrefab) as GameObject;
        DefenderSpawned.transform.position = SnapToGrid(CalculateRawWorldPointOfMouseClick());
        DefenderSpawned.transform.parent = DefenderParent.transform;

    }

    Vector2 CalculateRawWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTripled = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector3 rawWorldPosition = myGameCamera.ScreenToWorldPoint(weirdTripled);

        return rawWorldPosition;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPosition)
    {
    float WorldPositionX = Mathf.RoundToInt(rawWorldPosition.x);
    float WorldPositionY = Mathf.RoundToInt(rawWorldPosition.y);
    Vector2 IntWorldPosition = new Vector2 (WorldPositionX, WorldPositionY);
        return IntWorldPosition;
    }
}