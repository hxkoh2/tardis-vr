using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    public GameObject otherPortal;
    GameObject player;
    Rigidbody rigidbody;
    GameObject outsideCamera;
    GameObject insideCamera;
    bool world;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Cube");
        rigidbody = GameObject.Find("Cube").GetComponent<Rigidbody>();
        outsideCamera = GameObject.Find("OutsideCamera");
        insideCamera = GameObject.Find("InsideCamera");
        world = true;
	}
	
	// Update is called once per frame
	void Update () {
        world = rigidbody.position.y >= 0;
        GameObject camera;
        if (world)
        {
            Debug.Log("changing inside camera");
            camera = insideCamera;
        }
        else
        {
            Debug.Log("changing outside camera");
            camera = outsideCamera;
        }
        /*float angle = 0.0F;
        Vector3 axis = Vector3.zero;
        Quaternion.LookRotation(transform.position - player.transform.position).ToAngleAxis(out angle, out axis);
        camera.transform.Rotate(axis, angle);*/
        camera.transform.rotation = Quaternion.LookRotation(transform.forward - player.transform.forward - player.transform.GetChild(0).forward);
        camera.GetComponent<Camera>().fieldOfView = Mathf.Min(133, Mathf.Max(70, 150 - 8*(Mathf.Abs((transform.position - player.transform.position).magnitude))));
        Debug.Log("position " + (150 - 8 * (Mathf.Abs((transform.position - player.transform.position).magnitude))));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rigidbody.isKinematic = !rigidbody.isKinematic;
            world = rigidbody.position.y < 0;
            Debug.Log(world);
            if (world)
            {
                other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 2 - otherPortal.transform.up;
            }
            if (!world)
            {
                other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 2 + 0.5f * otherPortal.transform.up;
            }
            //other.transform.rotation = other.transform.rotation;
            other.transform.Rotate(0, 180, 0);
        }
    }
}
