using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCheats : MonoBehaviour {
    void Update() {
        DevLoadNextLevel();
        if (Input.GetKeyDown(KeyCode.C)) {
            GetComponent<CollisionHandler>().SwitchCollisionState();
        }
    }



    void DevLoadNextLevel() {
        if (Input.GetKeyDown(KeyCode.L)) {
            GetComponent<CollisionHandler>().LoadNextLevel();
            Debug.Log("Loading next level");
        }
    }
}
