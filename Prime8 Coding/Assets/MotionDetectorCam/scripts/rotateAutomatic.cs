using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAutomatic : MonoBehaviour {

	public float speed = 10f;

	void Update()  {

		transform.Rotate(new Vector3 (0.5f, 1f, 0.3f) * Time.deltaTime*speed);

	}
}
