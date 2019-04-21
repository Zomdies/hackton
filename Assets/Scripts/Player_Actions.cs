using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Actions : MonoBehaviour {
    Player p = new Player();
    public GameObject dead;
    public GameObject FP,B,FB;
    bool pos = true;
    public float helth;
    bool flag = false;
    public GameObject t,it;
    void Update () {
        helth = Player.Hp;
        if (helth<=0)
        {   
            
            it.active = true;
            t.active= true;
          if(!flag) {
             t.gameObject.GetComponent<AudioSource>().Play();  
            flag = true;
          }
           
            //Time.timeScale = 0;
            Player.Hp = 100;
            SceneManager.LoadScene(0);
        }
        p.GetDownEnergy(Time.deltaTime);
		if(Input.GetKey(KeyCode.E))
        {
           if(pos) StartCoroutine(shoot());
        }
        if (Input.GetKey(KeyCode.R))
        {
            Flaeme();
        }
    }
    void Flaeme()
    {
        Instantiate(FB, FP.transform.position+transform.right*0.01f, FP.transform.rotation*Quaternion.Euler(0,0,Mathf.Pow(-1, Random.Range(1,3))*Random.Range(0,31)));
    }
    IEnumerator shoot()
    {
        Instantiate(B, FP.transform.position, FP.transform.rotation);
        pos = false;
        yield return new WaitForSeconds(0.25f);
        pos = true;
    }
}

