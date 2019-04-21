using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        transform.position = GameObject.Find("Player").transform.position+new Vector3(0,0f,-10);
	}
}
