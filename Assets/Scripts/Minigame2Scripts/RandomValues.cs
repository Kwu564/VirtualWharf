using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Rewired;
using UnityEngine;
// TODO: Add timer, art, info, and scores
public class RandomValues : MonoBehaviour {
	public GameObject Pole1;
	public GameObject Pole2;
	public GameObject Pole3;
	public GameObject Pole4;
	public bool SelectedPole;
	public bool ObjectSelected;
	public bool ShowEx1;
	public bool ShowEx2;
	public bool ShowEx3;
	public bool ShowEx4;
	public bool TogglePole;
	public int RandomizedVal;
	public int RandomizedValue;
	private Player PlayerOne;
	private Player PlayerTwo;
	// Fill these values with fish?
	private int[] Exclam=new int[] {0,1,2,3};
	public int[] SelectedFish= new int[] {0,1,2,3};
	public Text FirstExclam;
	public Text SecondExclam;
	public Text ThirdExclam;
	public Text FourthExclam;

	// Use this for initialization
	void Start (){
		PlayerOne=ReInput.players.GetPlayer (0);
		PlayerTwo = ReInput.players.GetPlayer (1);
		RandomizedValue = (Exclam [Random.Range (0, Exclam.Length)]);
		ShowEx1 = false;
		ShowEx2 = false;
		ShowEx3 = false;
		ShowEx4 = false;
		ObjectSelected = false;
		SelectedPole = false;
	}
	void CheckForCorrectness(){
			if ((PlayerOne.GetButtonDown ("FirstPole") || PlayerTwo.GetButtonDown ("FirstPole")) && (RandomizedValue == 0)) {
				ConditionsOfPole ();
				// Add points
				ShowEx1 = false;
				ShowEx2 = false;
				ShowEx3 = false;
				ShowEx4 = false;
				RandomizedValue = (Exclam [Random.Range (0, Exclam.Length)]);
			//	Destroy (Pole1);
			} else if ((PlayerOne.GetButtonDown ("FirstPole") || PlayerTwo.GetButtonDown ("FirstPole")) && (RandomizedValue != 0)) {
				ShowEx1 = false;
				ShowEx2 = false;
				ShowEx3 = false;
				ShowEx4 = false;
				Debug.Log ("0 POINTS");
			} else if ((PlayerOne.GetButtonDown ("SecPole") || PlayerTwo.GetButtonDown ("SecPole")) && (RandomizedValue == 1)) {
				
				ConditionsOfPole ();
				// Add points
				ShowEx1 = false;
				ShowEx2 = false;
				ShowEx3 = false;
				ShowEx4 = false;
				RandomizedValue = (Exclam [Random.Range (0, Exclam.Length)]);
			} else if ((PlayerOne.GetButtonDown ("SecPole") || PlayerTwo.GetButtonDown ("SecPole")) && (RandomizedValue != 1)) {
				ShowEx1 = false;
				ShowEx2 = false;
				ShowEx3 = false;
				ShowEx4 = false;
				Debug.Log ("0 POINTS");
			} else if ((PlayerOne.GetButtonDown ("ThirdPole") || PlayerTwo.GetButtonDown ("ThirdPole")) && (RandomizedValue == 2)) {

				ConditionsOfPole ();
				// Add points
				ShowEx1 = false;
				ShowEx2 = false;
				ShowEx3 = false;
				ShowEx4 = false;
				RandomizedValue = (Exclam [Random.Range (0, Exclam.Length)]);
			} else if ((PlayerOne.GetButtonDown ("ThirdPole") || PlayerTwo.GetButtonDown ("ThirdPole")) && (RandomizedValue != 2)) {
				ShowEx1 = false;
				ShowEx2 = false;
				ShowEx3 = false;
				ShowEx4 = false;
				Debug.Log ("0 POINTS");
			} else if ((PlayerOne.GetButtonDown ("FourthPole") || PlayerTwo.GetButtonDown ("FourthPole")) && (RandomizedValue == 3)) {
				
				ConditionsOfPole ();
				// Add points
				ShowEx1 = false;
				ShowEx2 = false;
				ShowEx3 = false;
				ShowEx4 = false;
				RandomizedValue = (Exclam [Random.Range (0, Exclam.Length)]);
			} else if ((PlayerOne.GetButtonDown ("FourthPole") || PlayerTwo.GetButtonDown ("FourthPole")) && (RandomizedValue != 3)) {
				ShowEx1 = false;
				ShowEx2 = false;
				ShowEx3 = false;
				ShowEx4 = false;
				Debug.Log ("0 POINTS");
			}
	}
	void ShowExclamationMark(){
		if (ShowEx1) {
			FirstExclam.gameObject.SetActive (true);
		} else if (!ShowEx1) {
			FirstExclam.gameObject.SetActive (false);
		}
		if (ShowEx2) {
			SecondExclam.gameObject.SetActive (true);
		} else if (!ShowEx2) {
			SecondExclam.gameObject.SetActive (false);
		}
		if (ShowEx3) {
			ThirdExclam.gameObject.SetActive (true);
		} else if (!ShowEx3) {
			ThirdExclam.gameObject.SetActive (false);
		}if (ShowEx4) {
			FourthExclam.gameObject.SetActive (true);
		} else if (!ShowEx4) {
			FourthExclam.gameObject.SetActive (false);
		}
	}
	void ExclamationMarkConditions(){
		if (RandomizedValue == 0) {
			ShowEx1 = true;
			ShowEx2 = false;
			ShowEx3 = false;
			ShowEx4 = false;
		}
		if (RandomizedValue == 1) {
			ShowEx1 = false;
			ShowEx2 = true;
			ShowEx3 = false;
			ShowEx4 = false;
		}
		if (RandomizedValue == 2) {
			ShowEx1 = false;
			ShowEx2 = false;
			ShowEx3 = true;
			ShowEx4 = false;
		}
		if (RandomizedValue == 3) {
			ShowEx1 = false;
			ShowEx2 = false;
			ShowEx3 = false;
			ShowEx4 = true;
		}
	}
	void ConditionsOfPole(){
			RandomizedVal = (SelectedFish [Random.Range (0, SelectedFish.Length)]);
			// Show fish here
			if (RandomizedVal == 0) {
				Debug.Log ("You got 0");
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
	}
	// Update is called once per frame
	void Update () {
		ExclamationMarkConditions ();
		ShowExclamationMark ();
		CheckForCorrectness ();
		if (!ObjectSelected) {
			TogglePole = false;
		} 
		else if (ObjectSelected) {
			TogglePole = true;
		}
	}
}
