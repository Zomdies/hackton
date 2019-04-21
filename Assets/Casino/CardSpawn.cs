using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawn : MonoBehaviour {
    public GameObject a,b;
    bool s=false;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (b.GetComponent<Area>().ent && !s)
        {
            StartCoroutine(Spawn());
            s = !s;
        }
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(a, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
