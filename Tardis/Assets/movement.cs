using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    // Use this for initialization
    Rigidbody rb;
    CharacterController controller;
    TerrainData terrainData;
    Transform camera;
    public GameObject canvas;
    static bool menu = true;
    GameObject inside;

	void Start () {
        //rb = GetComponent<Collider>().attachedRigidbody;
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        camera = transform.Find("Camera");
        canvas.transform.position = transform.position + camera.forward * 2.5f + Vector3.up;
        canvas.transform.rotation = camera.rotation;
        canvas.SetActive(menu);
        inside = GameObject.Find("Inside");
    }
	
	// Update is called once per frame
	void Update () {

        // turn on canvas
        if (Input.GetButtonDown("Fire2"))
        {
            menu = !menu;
            if (menu) {
                canvas.transform.position = transform.position + camera.forward * 2.5f + Vector3.up;
                canvas.transform.rotation = camera.rotation;
            }

            canvas.SetActive(menu);
        }

        //if (domeCollider.colliding)
       //     return;

        Vector3 newPosition = transform.position;
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2)
        {
            newPosition += transform.right * Input.GetAxis("Horizontal") * .02f;
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2)
        {
            newPosition += transform.forward * Input.GetAxis("Vertical") * .02f;
        }
        float distanceFromCenter = Vector3.Distance(newPosition, inside.transform.position);
        if ((distanceFromCenter > 3 && distanceFromCenter < 8.5f && transform.position.y < 0) || transform.position.y >= 0)
            //rb.MovePosition(newPosition);
            rb.transform.position = newPosition;

        if (Mathf.Abs(Input.GetAxis("H2")) > 0.2)
        {
            Debug.Log("rotating");
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * Input.GetAxis("H2") * 20);
        }

    }
}
