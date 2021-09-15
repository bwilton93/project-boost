using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour {
    [SerializeField] Vector3 movementVector;
    [SerializeField] float moveSpeed;
    [SerializeField] AudioClip doorSwitchActivated;
    
    Vector3 doorStartingPosition;
    Vector3 doorFinishPosition;
    bool doorActivated = false;

    public Transform door;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {
        doorStartingPosition = door.position;
        doorFinishPosition = doorStartingPosition + movementVector;

        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (doorActivated) {
            OpenDoor();
        }
    }

    void OpenDoor() {
        float step = moveSpeed * Time.deltaTime; // Calculate movement distance
        door.position = Vector3.MoveTowards(door.position, doorFinishPosition, step);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision other) {
        if (!doorActivated) {
            audioSource.PlayOneShot(doorSwitchActivated);
            doorActivated = true;
            Debug.Log("Door switch activated");
            ChangeSwitchMaterial();
        }
    }

    private void ChangeSwitchMaterial() {
        // Get parent game object and find total number of children objects
        GameObject parent = transform.parent.gameObject;
        int numOfChildren = parent.transform.childCount;

        GameObject launchPad = GameObject.Find("Launch Pad");
        Material launchPadMat = launchPad.GetComponent<MeshRenderer>().material;

        // Loop through all children game objects
        for (int i = 0; i < numOfChildren; i++) {
            GameObject child = parent.transform.GetChild(i).gameObject;
            child.GetComponent<MeshRenderer>().material = launchPadMat;
        }
    }

}
