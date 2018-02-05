using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomValues : MonoBehaviour {
	public GameObject PoleNum;
	public bool SelectedPole;
	public bool ObjectSelected;
	public bool TogglePole;
	public int RandomizedVal;
	// Fill these values with fish?
	public int[] SelectedFish= new int[] {0,1,2,3};

	// Use this for initialization
	void Start (){
		//Debug.Log (SelectedFish [Random.Range (0, SelectedFish.Length)]);
		/*for(int i=0; i<=3; i++){
			Debug.Log (SelectedFish [Random.Range (0, SelectedFish.Length)]);
		}
		*/
		ObjectSelected = false;
		SelectedPole = false;
	}
	void OnMouseEnter(){
		//Debug.Log ("In Pole");
		SelectedPole = true;
	}

	// Checking if mouse is on button
	public void OnMouseOver(){
		SelectedPole = true;
		if (Input.GetMouseButtonDown (0) && (!TogglePole)) {
			RandomizedVal=(SelectedFish [Random.Range (0, SelectedFish.Length)]);
			Debug.Log (RandomizedVal);
			Debug.Log ("Selected");
			// Show fish here
			if (RandomizedVal == 0) {
				Debug.Log ("HAHA YOU GOT NOTHING");
			}
			if (RandomizedVal == 1) {
				Debug.Log ("You got 1");
			}
			if (RandomizedVal == 2) {
				Debug.Log ("You got 2");
			}
			if (RandomizedVal == 3) {
				Debug.Log ("You got 3");
			}
			ObjectSelected = true;
			//	Debug.Log (SelectedFish [Random.Range (0, SelectedFish.Length)]);
		}else if(Input.GetButtonDown("Submit")){ //checks if x button is down
		//	Debug.Log("Tap!");
		}
	}

	// Checking if mouse is not on button anymore
	void OnMouseExit(){
		SelectedPole = false;
		//Debug.Log ("ByeBye");
	}
	// Update is called once per frame
	void Update () {
		if (!ObjectSelected) {
			TogglePole = false;
		} 
		else if (ObjectSelected) {
			TogglePole = true;
		}
	}

}
