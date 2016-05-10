using UnityEngine;
using System.Collections;

public class BoneCrack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
