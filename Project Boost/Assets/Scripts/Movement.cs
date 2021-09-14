using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] float thrustForce = 800f;
    [SerializeField] float rotationSpeed = 150f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float pitchLow = 0.6f;
    [SerializeField] float pitchHigh = 1.0f;

    [SerializeField] ParticleSystem mainThrust;
    [SerializeField] ParticleSystem thrustLF;
    [SerializeField] ParticleSystem thrustLR;
    [SerializeField] ParticleSystem thrustRF;
    [SerializeField] ParticleSystem thrustRR;

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
        PlayEngineSound();
    }


    void ProcessThrust() {
        if (Input.GetKey(KeyCode.Space)) {
            ApplyThrust();
        } else {
            StopThrust();
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            playSideThrust(thrustRF, thrustRR);
            RotateShip(rotationSpeed);
        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            playSideThrust(thrustLF, thrustLR);
            RotateShip(-rotationSpeed);
        } else {
            StopSideThrust();
        }
    }

    void PlayEngineSound() {
        if (isAlive && !audioSource.isPlaying) {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    void ApplyThrust() {
        Debug.Log("Pressed SPACE - Thrust applied");
        rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        audioSource.pitch = pitchHigh;
        PlayMainThrust();
    }

    void PlayMainThrust() {
        if (!mainThrust.isPlaying) {
            mainThrust.Play();
        }
    }

    void StopThrust() {
        audioSource.pitch = pitchLow;
        mainThrust.Stop();
    }


    void RotateShip(float rotationThisFrame) {
        rb.freezeRotation = true; // Freezing physics rotation so we can manually rotate the ship
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ; // This goes back to using physics engine constraints
    }

    void playSideThrust(ParticleSystem particle1, ParticleSystem particle2) {
        if (!particle1.isPlaying && !particle2.isPlaying) {
            particle1.Play();
            particle2.Play();
        }
    }

    void StopSideThrust() {
        thrustLF.Stop();
        thrustLR.Stop();
        thrustRF.Stop();
        thrustRR.Stop();
    }

}
