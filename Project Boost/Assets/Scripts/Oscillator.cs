using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    void Start() {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    void Update() {
        if (period <= Mathf.Epsilon) { return; } // Protects against NaN error
        // Mathf.Epsilon is the smallest float available

        float cycles = Time.time / period; // Constantly grows over time

        const float tau = Mathf.PI * 2; // Constant value of 6.283
        float rawSinWave = Mathf.Sin(tau * cycles); // Going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; // Recalculated sin wave now goes between 0 and 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
