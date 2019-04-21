using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_B : MonoBehaviour {
    public float speed=10f;
    float z = 0;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.tag=="FBullet")
        {
            z += 10;
            transform.rotation = Quaternion.Euler(0, 0, z);
        }
	}
    private void OnTriggerEnter2D(Collider2D Hit_body)
    { 
       if (Hit_body.tag== "Enemy") Destroy(gameObject);
    }
}
