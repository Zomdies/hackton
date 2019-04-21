using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {
    bool f = true;
    public GameObject A_LU, A_LD, A_RU, A_RD;
    void Start () {
        StartCoroutine(Switch());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator  Switch()
    {
       Debug.Log("Puff:" + Time.time);
        
        while (Boss.Hp>0)
        {

            if (f)
            {
                A_RD.active = true;
                A_LD.active = true;
                A_RU.active = false;
                A_LU.active = false;
                f = false;
            }
            else
            {
                A_RU.active = true;
                A_LU.active = true;
                A_RD.active = false;
                A_LD.active = false;
                f = true;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
}

public class Boss
    {
    public static int Hp = 100;
    public void Hit(int i)
    {
        Hp -= i;
    }
    }
