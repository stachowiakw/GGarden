using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    public GameObject projectile;
    public GameObject gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner[] AllSpawners;
    private Spawner SpawnerInDefendersLine;
    private ScoreController scoreController;
    public int defenderCost;

    private void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();
        AllSpawners = GameObject.FindObjectsOfType<Spawner>();
        setDefendersSpawner();
        scoreController = GameObject.FindObjectOfType<ScoreController>();

        projectileParent = GameObject.Find("ProjectileParent");
        if (!projectileParent)
        {
            projectileParent = new GameObject("ProjectileParent");
        }
        useStarPoint();
    }
    private void Update()
    {
        if (gun)
        {
            if (isAttackerAheadInLane())
            {
                animator.SetBool("isAttacking", true);
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }

    private void setDefendersSpawner()
    {
        foreach (Spawner SpawnerLine in AllSpawners)
        {
            if (SpawnerLine.transform.position.y == transform.position.y)
            {
                SpawnerInDefendersLine = SpawnerLine;
                return;
            }

        }
    }

    bool isAttackerAheadInLane()
    {
        //exit if no attackers in line
        if (SpawnerInDefendersLine.transform.childCount <=0)
            {
                return false;
            }

        //if there are attackers, are they ahead?
        foreach (Transform child in SpawnerInDefendersLine.transform)
        {
            if (child.transform.position.x > transform.position.x)
            {
                return true;
            }
        }
        return false;
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("No elo makrelo: " + name);
    }

    public void ThrowProjectile()
    {
        GameObject ProjectileSpawned = Instantiate(projectile) as GameObject;
        ProjectileSpawned.transform.position = gun.transform.position;
        ProjectileSpawned.transform.parent = projectileParent.transform;
        //GameObject ProjectileSpawned = Instantiate(projectile, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity) as GameObject;
    }

    void addStarPoint(int addedScore)
    {
        scoreController.score = scoreController.score + addedScore;
    }

    public void useStarPoint()
    {
        scoreController.score -= defenderCost;
        if (scoreController.score < 0)
        {
            scoreController.score = 0;
        }
    }
}
