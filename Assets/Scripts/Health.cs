﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health;
    public Attacker attackersAttacker;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

    }

    public void UpdateRightToLive()
    {
        if (health > 0) { return; }
        else {
            Destroy(gameObject);
        }
    }
}