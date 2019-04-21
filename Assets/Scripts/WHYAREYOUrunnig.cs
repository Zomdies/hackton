using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WHYAREYOUrunnig : MonoBehaviour {
    public GameObject InTrig;
    
    public float spead;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    bool flag = false;
	void Update () {
		if (InTrig.GetComponent<InArea>().Out && GameObject.FindGameObjectWithTag("Player").transform.position.x > transform.position.x)
        {
            InTrig.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1*spead,0);
            if (!flag){
                gameObject.GetComponent<AudioSource>().Play();
                flag = true;
            } 
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Player" && InTrig.GetComponent<InArea>().Out && GameObject.FindGameObjectWithTag("Player").transform.position.x > transform.position.x) Player.Hp = 0;
    }
}
