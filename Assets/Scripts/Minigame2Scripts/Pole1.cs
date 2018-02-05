using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Animations;
using UnityEngine.UI;

// Hover on button, and it expands.
// Collision detection is only on the circle instead of the whole button

public class Pole1 : MonoBehaviour{
	public GameObject FirstPole;
	public bool SelectedPole;
	// Fill these values with fish?
	public int[] SelectedFish= new int[] {0,1,2,3,4,5};
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
		Debug.Log ("In Pole1");
		SelectedPole = true;
	}
		
	// Checking if mouse is on button
	public void OnMouseOver(){
		SelectedPole = true;
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("First Click");
			Debug.Log (SelectedFish [Random.Range (0, SelectedFish.Length)]);
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