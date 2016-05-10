using UnityEngine;
using System.Collections;

public class RunTrigger : MonoBehaviour {

    public GameObject runner;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        runner.GetComponent<Animation>().Play();
        runner.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
