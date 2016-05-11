using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public GameObject otherPortal;
    GameObject player;
    Rigidbody rigidbody;
    GameObject outsideCamera;
    GameObject insideCamera;
    bool world;
    bool starship;
    static Vector3 prevPosition = new Vector3(0,0,0);
    static bool startGame = true;
    static Quaternion prevRotation = new Quaternion(0, 0, 0, 0);

    GameObject camera;
    GameObject otherCamera;

    // Use this for initialization
    void Start () {
        Debug.Log("hit start");
        player = GameObject.Find("Cube");
        rigidbody = GameObject.Find("Cube").GetComponent<Rigidbody>();
        outsideCamera = GameObject.Find("OutsideCamera");
        insideCamera = GameObject.Find("InsideCamera");
        world = true;
        if (SceneManager.GetActiveScene().buildIndex == 0)
            starship = true;
        else
            starship = false;
        if(!startGame)
        {
            player.transform.position = GameObject.Find("tardis_inside").transform.position + prevPosition;
            player.transform.rotation = prevRotation;
            rigidbody.isKinematic = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        world = rigidbody.position.y >= 0;
        
        if (world)
        {
            camera = insideCamera;
            otherCamera = outsideCamera;
        }
        else
        {
            camera = outsideCamera;
            otherCamera = insideCamera;
        }
       
        camera.transform.rotation = Quaternion.LookRotation(transform.forward - player.transform.forward - player.transform.GetChild(0).forward);
        camera.GetComponent<Camera>().fieldOfView = Mathf.Min(133, Mathf.Max(70, 120 - 8*(Mathf.Abs((otherCamera.transform.position - player.transform.position).magnitude))));
        if (Input.GetButtonDown("Fire1") && player.transform.position.y < 0)
        {
            startGame = false;
            prevPosition = - GameObject.Find("tardis_inside").transform.position + player.transform.position;
            prevRotation = player.transform.rotation;
            if (starship)
            {
                SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
                SceneManager.UnloadScene(0);
            }
            else
            {
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
                SceneManager.UnloadScene(1);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rigidbody.isKinematic = !rigidbody.isKinematic;
            world = rigidbody.position.y < 0;
            if (world)
            {
                other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 2 - otherPortal.transform.up;
                
            }
            if (!world)
            {
                other.transform.position = otherPortal.transform.position + 1.5f* otherPortal.transform.forward;
                other.transform.position = new Vector3(other.transform.position.x, - 53.1f, other.transform.position.z);
            }

            other.transform.Rotate(0, 180, 0);
            other.transform.rotation = Quaternion.LookRotation(other.transform.forward, otherPortal.transform.up);
        }
    }
}
