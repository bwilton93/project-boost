using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] float thrustForce = 800f;
    [SerializeField] float rotationSpeed = 150f;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("Pressed SPACE - Thrust applied");
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            Debug.Log("Pressed LEFT - Rocket turned left");
            RotateShip(rotationSpeed);
        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            Debug.Log("Pressed RIGHT - Rocket turned right");
            RotateShip(-rotationSpeed);
        }
    }

    void RotateShip(float rotationThisFrame) {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}
