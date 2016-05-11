#pragma strict

var opened = 0;

function OnTriggerEnter (obj : Collider) {
    if(opened == 0)
    {
        var thedoor = gameObject.FindWithTag("SF_Door");
        thedoor.GetComponent.<Animation>().Play("open");
        opened = 1;
    }
	
}
