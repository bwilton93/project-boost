using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("You win!");
        GameObject.Find("Rocket").GetComponent<Movement>().rb.velocity = new Vector3(0, 0, 0);
    }
}
