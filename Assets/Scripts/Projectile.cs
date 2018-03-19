using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed, damage;
    private GameObject CurrentTarget;
    private Health CurrentTargetHealthComponent;

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CurrentTarget = collision.gameObject;
        StrikeCurrentTarget();
    }

    private void StrikeCurrentTarget() {
        
        if (!CurrentTarget.GetComponent<Attacker>())
        {
            return;
        }
        CurrentTargetHealthComponent = CurrentTarget.GetComponent<Health>();
        if (CurrentTargetHealthComponent)
        {
            CurrentTargetHealthComponent.health -= damage;
            CurrentTargetHealthComponent.UpdateRightToLive();
        }

        Destroy(gameObject);
    }
}
