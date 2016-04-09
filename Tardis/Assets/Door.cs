using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public GameObject otherPortal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hit something");
            other.transform.position = otherPortal.transform.position + otherPortal.transform.forward;
            other.transform.rotation = otherPortal.transform.rotation;
        }
    }
}
