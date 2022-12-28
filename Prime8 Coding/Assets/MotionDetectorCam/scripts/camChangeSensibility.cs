using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChangeSensibility : MonoBehaviour {

	public GameObject camDetection;
	public float newValue;

    public void newSensibility() {
        
		camDetection.GetComponent<camMotionDetection>().sensibility = newValue;

    }
}
