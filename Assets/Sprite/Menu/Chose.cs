using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Chose : MonoBehaviour {

	public int chose = 0;

	void Update(){
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.position = new Vector2 (transform.position.x,-2.91f);
			chose = 1;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.position = new Vector2 (transform.position.x,-1.44f);
			chose = 0;
		}
		if (Input.GetKey(KeyCode.KeypadEnter)) {
			Debug.Log("Enter");
			if(chose == 0) {
				SceneManager.LoadScene("SampleScene");
				Debug.Log("Load Level");
			}
			if(chose == 1) {
				Application.Quit();
				Debug.Log("Exit");
			} 
		}
	}
}
