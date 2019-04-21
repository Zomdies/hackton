using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {
    public bool ent=false;
	public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	bool flag = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ent = true;
		if (!flag)
		{
			StartCoroutine("audioclip",3);
			flag = true;
		}
    }
	int check = 0;
	IEnumerator audioclip() {
		obj.GetComponent<CasioBoss>().audioCasino[check].Play(); 
		check++;
		yield return new WaitForSeconds(4f);
		
	}
}
