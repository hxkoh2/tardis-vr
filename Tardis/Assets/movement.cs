using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position -= transform.right * .05f;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += transform.right * .05f;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position -= transform.forward*.05f;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward*.05f;
        }


        if (Input.GetAxis("H2") < -0.2)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * -15);
        }
        else if (Input.GetAxis("H2") > 0.2)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 15);
        }
    }
}
