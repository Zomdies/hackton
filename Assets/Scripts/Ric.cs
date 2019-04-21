using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ric : MonoBehaviour {

    public float z = 0,s=0.5f;
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        z +=1;
       // Debug.Log(z);
        transform.rotation = Quaternion.Euler(0, 0, z) ;
        transform.position += new Vector3(0, -s, 0)*Time.deltaTime;
	}
}
