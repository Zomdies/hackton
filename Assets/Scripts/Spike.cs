using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {
    public float xforce, yforce;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player.Hp -= 5; // Минус хп
            if (Player.Hp > 0)
            {
                if (other.GetComponent<Movement>().n) other.GetComponent<Rigidbody2D>().velocity = new Vector2(-xforce, yforce);
                else other.GetComponent<Rigidbody2D>().velocity = new Vector2(xforce, yforce);
            }
        }
    }
    
}
