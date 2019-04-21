using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {
     public float Bounceborce=4;
    public GameObject a;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-80, 15*Bounceborce));
        StartCoroutine(SpawnShad());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") Player.Hp -= 20;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-80, 15 * Bounceborce));
        Bounceborce *=0.75f;
    }
    IEnumerator SpawnShad()
    {
        while (true)
        {
            Instantiate(a, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
