using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasioBoss : MonoBehaviour {
    public int hp=100;
	
	public  AudioSource[] audioCasino;
    public GameObject a;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (a.GetComponent<Area>().ent) GetComponent<Animator>().SetBool("Up",true);
		if (hp<1) Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D c)
	{
		if( c.tag =="FBullet") hp-=1;
	}
}
