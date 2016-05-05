using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    // Use this for initialization
    Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") < -0.2)
        {
            rb.MovePosition(transform.position - transform.right * .05f);
        }
        else if (Input.GetAxis("Horizontal") > 0.2)
        {
            rb.MovePosition(transform.position + transform.right * .05f);
        }

        if (Input.GetAxis("Vertical") < -0.2)
        {
            rb.MovePosition(transform.position - transform.forward*.05f);
        }
        else if (Input.GetAxis("Vertical") > 0.2)
        {
            rb.MovePosition(transform.position + transform.forward*.05f);
        }


        if (Input.GetAxis("H2") < -0.2)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * -30);
            if (Input.GetAxis("H2") < -0.8)
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * -55);
        }
        else if (Input.GetAxis("H2") > 0.2)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 30);
            if (Input.GetAxis("H2") > 0.8)
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * 55);
        }
    }
}
