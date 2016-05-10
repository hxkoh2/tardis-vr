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
        Debug.Log(prevPosition);
        if(!startGame)
        {
            player.transform.position = GameObject.Find("tardis_inside").transform.position + prevPosition;
            rigidbody.isKinematic = true;
        }
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
       
        camera.transform.rotation = Quaternion.LookRotation(transform.forward - player.transform.forward - player.transform.GetChild(0).forward);
        camera.GetComponent<Camera>().fieldOfView = Mathf.Min(133, Mathf.Max(70, 150 - 8*(Mathf.Abs((transform.position - player.transform.position).magnitude))));

        if (Input.GetKeyDown("j") && player.transform.position.y < 0)
        {
            Debug.Log("change scene");
            startGame = false;
            prevPosition = - GameObject.Find("tardis_inside").transform.position + player.transform.position;
            Debug.Log(prevPosition);
            if(starship)
                SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            else
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }
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
            other.transform.Rotate(0, 180, 0);
        }
    }
}
