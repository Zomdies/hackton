using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethTimer : MonoBehaviour {
    public float t;
	// Use this for initialization
	void Start () {
        StartCoroutine(Death());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Death()
    {
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }
}
