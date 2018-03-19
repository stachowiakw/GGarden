using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
    public GameObject projectile;
    public GameObject gun;
    private GameObject projectileParent;

    private void Start()
    {
        projectileParent = GameObject.Find("ProjectileParent");
        if (!projectileParent)
        {
            projectileParent = new GameObject("ProjectileParent");
        }
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("No elo makrelo: " + name);
    }

    public void ThrowProjectile() {
        GameObject ProjectileSpawned = Instantiate(projectile) as GameObject;
        ProjectileSpawned.transform.position = gun.transform.position;
        ProjectileSpawned.transform.parent = projectileParent.transform;
        //GameObject ProjectileSpawned = Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity) as GameObject;
    }
}
