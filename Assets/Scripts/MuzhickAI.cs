using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzhickAI : MonoBehaviour {
    public GameObject Pl;
    public bool b,l;
    public bool pn;//Пердыдущее направление
    public float speed;
    public GameObject wall;
    // Use this for initialization
    public Muzh m = new Muzh();
    void Start () {
        pn = m.n;
        Pl = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        b = m.PlayerInRange;
        l = m.Attack;
        
        if (m.PlayerInRange)
        {
            m.CheckDir(Pl,gameObject);
            GetComponent<Animator>().SetBool("Attack", m.Attack);           
            if (m.n != pn)
            {             
                m.Flip(gameObject);
                pn = m.n;
            }
            if (m.n)
            {
                gameObject.transform.position += new Vector3(1, 0, 0) * speed*Time.deltaTime;
            }
            else
            {
                gameObject.transform.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }
        }       
        if (wall !=null)
        {
            if (m.Hp <= 0) wall.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (m.Hp <= 0)
        {
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<Animator>().SetBool("Live", false);
            Destroy(gameObject);
        }
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") Player.Hp -= 15;        
    }
}

public class Muzh
    {
    public static float t=0.1f;
    public bool n = true; //Направление взгляда t->  f<-
    public float Hp = 100;
    public bool Attack=false;
    public bool PlayerInRange = false;
    public bool PlayerInAttackZone = false;
    public float speed = 4f;
    public void Flip(GameObject a)
    {
        Debug.Log("Should Flip");
        a.transform.Rotate(0, 180, 0);
    }
    public void CheckDir(GameObject pl,GameObject m)
    {
        if (m.transform.position.x - pl.transform.position.x> t)
        {
            n = false;
        }
        if (pl.transform.position.x - m.transform.position.x > t)
        {
            n = true;
        }
    }
    }
