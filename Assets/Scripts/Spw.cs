using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spw : MonoBehaviour {
    public GameObject a;
	// Use this for initialization
	void Start () {
        StartCoroutine(Sp());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Sp()
    {
        Debug.Log("Puff:" + Time.time);

        while (true)
        {

            Instantiate(a, transform.position + Mathf.Pow(-1, Random.Range(1, 3))* new Vector3(Random.Range(0,10),0,0),Quaternion.identity );
            yield return new WaitForSeconds(1);
        }
    }
}
