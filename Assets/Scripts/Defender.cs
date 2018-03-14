using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
    public GameObject projectile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D()
    {
        Debug.Log("No elo makrelo: " + name);
    }

    public void ThrowProjectile() {
        Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,-1), Quaternion.identity);
    }
}
