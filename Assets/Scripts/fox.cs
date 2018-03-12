using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Fox collided with: " + collider);

        GameObject objThatItHasCollidedWith = collider.gameObject;

        // Leave the method if not colliding with degender

        if (!objThatItHasCollidedWith.GetComponent<Defender>())
        {
            return;
        }

        if (objThatItHasCollidedWith.GetComponent<Stone>())
        {
            anim.SetTrigger("jump Trigger");
        }
        else
        {
            attacker.Attack(objThatItHasCollidedWith);
            anim.SetBool("isAttacking", true);
        }
    }
}
