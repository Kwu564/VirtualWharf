using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class toScene : MonoBehaviour {
	public int distanceToItem;

	public void letsFish(){
		SceneManager.LoadScene (1);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		nextSceneFish ();
	}
	void nextSceneFish(){
		if(Input.GetMouseButtonUp(1)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast(ray, out hit, distanceToItem)){
				if(hit.collider.gameObject.name=="Door"){
					Debug.Log ("Let's go!!!");
					letsFish ();
				}
			}
		}
	}
}
