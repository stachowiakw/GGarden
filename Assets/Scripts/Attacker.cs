using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Tooltip("Avarange number of seconds between spawning attacker")]
    public float seenEverySeconds;

    [Range(0f, 2f)]
    private float currentSpeed;
    private GameObject currentTarget;
    private Health EnemyHealthComponent;
    private Health OwnHealthComponent;
    private Animator anim;

    // Use this for initialization
    void Start() {
        //Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        //myRigidbody.isKinematic = true;
        anim = GetComponent<Animator>();
        OwnHealthComponent = GetComponent<Health>();

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("No elo makrelo: " + name);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    //called from the animator
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            if (EnemyHealthComponent)
            {
                EnemyHealthComponent.health -= damage;
                EnemyHealthComponent.UpdateRightToLive();
            }
        }
        else
        {
            GoOn();
        }

    }

    public void Attack(GameObject objThatItHasCollidedWith)
    {
        currentTarget = objThatItHasCollidedWith;
        EnemyHealthComponent = currentTarget.GetComponent<Health>();
    }

    public void GoOn() { anim.SetBool("isAttacking", false); }

}
