using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustForce = 20f;

    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() 
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            Debug.Log("Pressed SPACE - Thrust applied");
            rb.AddRelativeForce(Vector3.up * thrustForce);
        }
    }

    void ProcessRotation() 
    {
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            Debug.Log("Pressed LEFT - Rocket turned left");
        } 
        else if (Input.GetKey(KeyCode.RightArrow)) 
        {
            Debug.Log("Pressed RIGHT - Rocket turned right");
        }
    }
}
