using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMove : MonoBehaviour {
    float x, sx,sy;
    public float scale;
    Vector3 s;
	// Use this for initialization
	void Start () {
        sx= GetComponent<RectTransform>().localPosition.x;
        sy= GetComponent<RectTransform>().localPosition.y;
        s = GetComponent<RectTransform>().localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        
        GetComponent<RectTransform>().localPosition= Vector3.LerpUnclamped(new Vector3(0, sy, 0), s, Player.Energy * 0.005f);
    }
}
