using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : MonoBehaviour {
    public GameObject Muzh;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Muzh.transform.position;        
	}
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag=="Player") Muzh.GetComponent<MuzhickAI>().m.PlayerInRange = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") Muzh.GetComponent<MuzhickAI>().m.PlayerInRange = false;
    }
}
