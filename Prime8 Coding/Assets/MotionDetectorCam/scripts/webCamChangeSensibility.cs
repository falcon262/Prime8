using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webCamChangeSensibility : MonoBehaviour {

	public GameObject webcamDetection;
	public float newValue;

    public void newSensibility() {
        
		webcamDetection.GetComponent<webCamMotionDetection>().sensibility = newValue;

    }
}
