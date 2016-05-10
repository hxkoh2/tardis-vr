using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    // Use this for initialization
    Rigidbody rb;
    CharacterController controller;
    TerrainData terrainData;
	void Start () {
        //rb = GetComponent<Collider>().attachedRigidbody;
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPosition = transform.position;
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2)
        {
            newPosition += transform.right * Input.GetAxis("Horizontal") * .05f;
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2)
        {
            newPosition += transform.forward * Input.GetAxis("Vertical") * .05f;
        }

        rb.MovePosition(newPosition);
       // transform.position = newPosition;

        if (Mathf.Abs(Input.GetAxis("H2")) > 0.2)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * Input.GetAxis("H2") * 20);
        }

    }
}
