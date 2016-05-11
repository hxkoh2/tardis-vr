using UnityEngine;
using System.Collections;

public class domeCollider : MonoBehaviour {
    public static bool colliding = false;
    GameObject player;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something Entered");
        if (other.tag == "Player")
        {
            colliding = true;
            //other.transform.position -= other.transform.forward;
            Debug.Log("Player entered");
           
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Something Exited");
        if (other.tag == "Player")
        {
            //other.transform.position -= other.transform.forward;
            Debug.Log("Player exited");
            Vector3 velocity = -1 * other.GetComponent<Rigidbody>().velocity;
            Debug.Log("Velocity: " + velocity);
            /*if (Physics.Raycast(other.transform.position, velocity, out hit))
            {
                Debug.Log("Hit");
                player.transform.position += hit.normal * -.1f;
            }*/
        }
    }
}
