using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    // Use this for initialization
    Vector3 startPosition;
    Quaternion startRotation;
    bool isKinematic;
	void Start () {
        startPosition = transform.position;
        startRotation = transform.rotation;
        isKinematic = transform.GetComponent<Rigidbody>().isKinematic;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Start"))
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
            transform.GetComponent<Rigidbody>().isKinematic = isKinematic;
        }
    }
}
