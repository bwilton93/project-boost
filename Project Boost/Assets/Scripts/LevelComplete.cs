using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour {
    Material newMaterial;
    // Start is called before the first frame update

    void Start() {
        newMaterial = GameObject.Find("Launch Pad").GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("You win!");
        GameObject.Find("Rocket").GetComponent<Movement>().rb.velocity = new Vector3(0, 0, 0);
        GetComponent<Renderer>().material = newMaterial;
    }
}
