using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public int combo_int = 1;
    public static int hit_person;
    public bool damege = false;
    void Start()
    {
        last_hp = Player.Hp; 
    }
    int a = 0;
    float last_hp;

    void Update()
    {   

        if (Player.Hp < last_hp)
        {
            last_hp = Player.Hp;
            damege = true;
        }
        if (!damege)
        {
            if (hit_person > a)
            {
                combo_int++;
                a = hit_person;
            }
        }
        else
        {
            combo_int = 1;
            damege = false;
            a = 0;
        }
     
    }
}
