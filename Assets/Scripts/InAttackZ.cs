using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAttackZ : MonoBehaviour {
    public GameObject Mu;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Mu.GetComponent<MuzhickAI>().m.Hp -= 25;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "FBullet")
        {
            Mu.GetComponent<MuzhickAI>().m.Hp -= 0.001f;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player") Mu.GetComponent<MuzhickAI>().m.Attack = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") Mu.GetComponent<MuzhickAI>().m.Attack = false;
    }
}
