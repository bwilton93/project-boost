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
                break;
            default:
                Debug.Log("This is the environment");
                SceneManager.LoadScene("Sandbox");
                break;
        }
    }
}
