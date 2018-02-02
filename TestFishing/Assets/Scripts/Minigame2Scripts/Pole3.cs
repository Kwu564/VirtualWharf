using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Animations;
using UnityEngine.UI;

// Hover on button, and it expands.
// Collision detection is only on the circle instead of the whole button

public class Pole3: MonoBehaviour{
	public GameObject ThirdPole;
	public bool SelectedPole;
	void Start(){
		SelectedPole = false;
	}
	void Update(){
		/*if (SelectedPole) {
			Debug.Log ("highlighted");
		}
*/
	}

	// Checking if mouse is entering button
	void OnMouseEnter(){
		Debug.Log ("In Pole3");
		SelectedPole = true;
	}

	// Checking if mouse is on button
	public void OnMouseOver(){
		SelectedPole = true;
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("First Click");
		}else if(Input.GetButtonDown("Submit")){ //checks if x button is down
			Debug.Log("First Tap!");
		}
	}

	// Checking if mouse is not on button anymore
	void OnMouseExit(){
		SelectedPole = false;
		Debug.Log ("Bye");
	}
}