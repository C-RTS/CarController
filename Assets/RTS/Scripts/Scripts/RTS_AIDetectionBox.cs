using UnityEngine;
using System.Collections;

public class RTS_AIDetectionBox : MonoBehaviour {

	public RTS_AIDetection detection;

	void Awake(){
		if (detection == null)	detection = transform.parent.parent.GetComponent<RTS_AIDetection> ();
	}

	void OnTriggerStay(Collider col){
		if (col.tag == "Car Collider") detection.forwardObstacle = true;
	}

	void OnTriggerExit(Collider col){
		detection.forwardObstacle = false;
	}

}