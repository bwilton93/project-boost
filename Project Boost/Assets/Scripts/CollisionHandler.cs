using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    public Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag) {
            case "Friendly":
                Debug.Log("This is a launchpad");
                rb.velocity = new Vector3(0, 0, 0);
                break;
            case "Finish":
                Debug.Log("This is a landing pad");
                rb.velocity = new Vector3(0, 0, 0);
                LoadNextLevel();
                break;
            default:
                Debug.Log("This is the environment");
                ReloadScene();
                break;
        }
    }

    void LoadNextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
