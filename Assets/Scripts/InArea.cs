using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InArea : MonoBehaviour {
    public bool Out=false;
    public GameObject block;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") Out = true;  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") Out = false;
        if (collision.tag == "Player") block.GetComponent<Collider2D>().enabled=true;
    }
}
