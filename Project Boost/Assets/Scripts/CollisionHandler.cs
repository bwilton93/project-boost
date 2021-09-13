using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip levelSuccess;
    float pitchHigh = 1.0f;

    public Rigidbody rb;
    public AudioSource audioSource;

    bool isTransitioning = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) {
        if (isTransitioning) { return; } 
        
        switch (other.gameObject.tag) {
            case "Friendly":
                Debug.Log("This is a launchpad");
                rb.velocity = new Vector3(0, 0, 0);
                break;
            case "Finish":
                Debug.Log("This is a landing pad");
                SuccessSequence();
                break;
            default:
                Debug.Log("This is the environment");
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence() {
        isTransitioning = true;
        // todo add crash particles
        GetComponent<Movement>().isAlive = false;
        GetComponent<Movement>().enabled = false;
        PlayExplosion();
        Invoke("ReloadScene", delayTime);
    }

    void SuccessSequence() {
        isTransitioning = true;
        rb.velocity = new Vector3(0, 0, 0);
        GetComponent<Movement>().isAlive = false;
        GetComponent<Movement>().enabled = false;

        GameObject landingPad = GameObject.Find("Landing Pad");
        GameObject launchPad = GameObject.Find("Launch Pad");
        landingPad.GetComponent<MeshRenderer>().material = launchPad.GetComponent<MeshRenderer>().material;

        PlaySuccess();
        Invoke("LoadNextLevel", delayTime);
    }

    private void PlayExplosion() {
        AudioReset();
        audioSource.PlayOneShot(explosionSound);
    }

    private void PlaySuccess() {
        AudioReset();
        audioSource.PlayOneShot(levelSuccess);
    }

    private void AudioReset() {
        audioSource.Stop();
        audioSource.pitch = pitchHigh;
    }

    void LoadNextLevel() {
        isTransitioning = false;
        GetComponent<Movement>().isAlive = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadScene() {
        isTransitioning = false;
        GetComponent<Movement>().isAlive = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
