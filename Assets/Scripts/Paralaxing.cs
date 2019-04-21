using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxing : MonoBehaviour {

    public Transform[] Bg;
    private float[] pScale;
    public float sm=1f;
    private Transform cam;
    private Vector3 prevpos;
    private void Awake()
    {
        cam = Camera.main.transform;
    }
    void Start () {
        prevpos = cam.position;
        pScale = new float[Bg.Length];
        for (int i=0;i<Bg.Length; i++)
        {
            pScale[i] = Bg[i].position.z * -1;
        }
	}

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < Bg.Length; i++)
        {
            float parallax = (prevpos.x - cam.position.x) * pScale[i];
            float bgTPosX = Bg[i].position.x + parallax;
            Vector3 bgTPos = new Vector3(bgTPosX, Bg[i].position.y, Bg[i].position.z);
            Bg[i].position = Vector3.Lerp(Bg[i].position, bgTPos, sm * Time.deltaTime);

        }
        prevpos = cam.position;
    }
}
