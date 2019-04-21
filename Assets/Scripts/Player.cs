using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject Obama;
    public AudioSource[] clip_Obama;
    public static float Energy=100, Hp=100;
    public void EnergyUp(float i)
    {
        Energy += i;
        if (Energy > 100) Energy = 100;
    }
    public void GetDownEnergy(float i)
    {
        Energy -= i;
    }
    void Start() {
        StartCoroutine("SpawnObama");
    }
    IEnumerator SpawnObama(){
		yield return new WaitForSeconds(Random.Range(10,20));
		Debug.Log("Spawn");
		if (Obama.active == false) {
          //  Obama.transform.localPosition = new Vector2 (Obama.transform.localPosition.x + Random.Range(-100,100) ,Obama.transform.localPosition.y + Random.Range(-100,100));
			//Instantiate(Obama, transform.position + Mathf.Pow(-1, Random.Range(1, 3))* new Vector3(Random.Range(0,10),0,0),Quaternion.identity );
        
            Obama.active = true;
			clip_Obama[Random.Range(0,2)].Play();
		}
		StartCoroutine("SpawnObama");
	}
    public void hide_obama(){
		Obama.active = false;
		
	}
}

	