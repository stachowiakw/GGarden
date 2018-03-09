using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(0f,2f)] public float walkSpeed;

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D()
    {
        Debug.Log("No elo makrelo: " + name);
    }
}
