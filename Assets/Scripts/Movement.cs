using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
    Vector2 h = new Vector2 (1, 0);
    Vector2 v = new Vector2(0, 1);
    public Player p = new Player();
    public float x;
    public float f =1.5f;//Скорость движения
    float jump_f = 5f;//Сила импульса
    public bool n=true;
    bool run;
    private void Start()
    {
        GetComponent<Animator>().SetBool("Run",false);
    }
    void Update () {
        h.y = GetComponent<Rigidbody2D>().velocity.y;

        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Animator>().SetBool("Down", true) ;
            
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            GetComponent<Animator>().SetBool("Down", false);

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GetComponent<Animator>().speed = 1.5f;
            f = 3f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            f = 1.5f;
            GetComponent<Animator>().speed = 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Animator>().SetBool("Run", true);
            GetComponent<Rigidbody2D>().velocity = (h * new Vector2(-f,1));
            if (n)
            {
                Flip();
                n = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)) GetComponent<Animator>().SetBool("Run", false);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Animator>().SetBool("Run", true);
            GetComponent<Rigidbody2D>().velocity=(h * new Vector2(f, 1));
            if (!n)
            {
                Flip();
                n = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Should Jump");
            Jump();
            GrabWall();
        }
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            GetComponent<Animator>().SetBool("Jump", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Jump", true);
        }
        GrabWall();
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Respawn")
        {   
            SceneManager.LoadScene(0);
            Player.Hp = 100;
            //transform.position = c.transform.position;
        }
        if (c.gameObject.tag == "Weed")
        {
            Player.Hp+=35;
            if (Player.Hp > 100) Player.Hp = 100;
            Destroy(c.gameObject);
        }

    }
    private void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Wall") GetComponent<Rigidbody2D>().velocity *= new Vector2(1, 0);
    }
    void GrabWall()
    {
        Ray2D ray2 = new Ray2D();
        ray2.origin = GameObject.Find("Grab_wall").transform.position;
        ray2.direction = Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(ray2.origin, ray2.direction, 0.1f);
        Debug.DrawRay(ray2.origin, ray2.direction, Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Wall")
            {
                GetComponent<Rigidbody2D>().velocity *= new Vector2(0, 1);              
            }
        }
    }
    void grounded()
    {
        Ray2D ray3 = new Ray2D();
        ray3.origin = GameObject.Find("Ground").transform.position;
        ray3.direction = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(ray3.origin, ray3.direction, 0.01f);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Floor")
            {
                GetComponent<Animator>().SetBool("Jump", false);
            }
        }
    }
    void Jump()
    {
        Ray2D ray = new Ray2D();
        ray.origin = GameObject.Find("Ground").transform.position;
        ray.direction = Vector2.down;
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction,0.1f);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Floor")
            {
                GetComponent<Rigidbody2D>().velocity = (v * jump_f);
                GetComponent<Animator>().SetBool("Jump", true);
            }
        }
        

        //if (hit.collider = "Floor")
        //{
        //    Debug.Log("Хуяк");
        //    GetComponent<Rigidbody2D>().velocity = (v * jump_f);
        //}
    }
    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
}

