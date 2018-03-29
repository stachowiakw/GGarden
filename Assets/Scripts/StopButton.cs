﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    private LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnMouseDown()
    {
        levelManager.LevelChange("01a Start");
    }
}
