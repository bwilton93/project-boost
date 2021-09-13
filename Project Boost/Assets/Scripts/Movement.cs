using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] float thrustForce = 800f;
    [SerializeField] float rotationSpeed = 150f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float pitchLow = 0.6f;
    [SerializeField] float pitchHigh = 1.0f;

    public Rigidbody rb;
    public AudioSource audioSource;

    public bool isAlive = true;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        ProcessThrust();
        ProcessRotation();
        if (isAlive && !audioSource.isPlaying) {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("Pressed SPACE - Thrust applied");
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
            audioSource.pitch = pitchHigh;
        } else {
            audioSource.pitch = pitchLow;
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
        rb.freezeRotation = true; // Freezing physics rotation so we can manually rotate the ship
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ; // This goes back to using physics engine constraints
    }
}
