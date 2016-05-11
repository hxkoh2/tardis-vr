using UnityEngine;
using System.Collections;

public class DoubleTrigger : MonoBehaviour {

    public GameObject runner1;
    public GameObject runner2;
    public GameObject triggeredBox;
    public ParticleSystem explosion;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        triggeredBox.SetActive(true);
        explosion.Play();
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(TimeDelay(0.5f));
        
       
    }

    IEnumerator TimeDelay(float time)
    {
        yield return new WaitForSeconds(time);
        runner1.GetComponent<Animation>().Play();
        runner1.GetComponent<AudioSource>().Play();
        runner2.GetComponent<Animation>().Play();
        runner2.GetComponent<AudioSource>().Play();
        explosion.Stop();
        triggeredBox.SetActive(false);
        Destroy(gameObject);
    }

}
