using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
    static GameObject SelectedPrefab;

    void OnTriggerEnter2D(Collider2D GameObjectColliding)
    {
        Destroy(GameObjectColliding.gameObject);
    }

    private void Update()
    {
        //print(Button.SelectedPrefab);
    }

  }
