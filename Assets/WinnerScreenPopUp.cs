using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinnerScreenPopUp : MonoBehaviour {
	public Text P1IsTheWinner;
	public Text P2IsTheWinner;
	public Text Tie;
	public bool P1Wins;
	public bool P2Wins;
	public bool ItsATie;

	// Use this for initialization
	void Start () {
		P1IsTheWinner.gameObject.SetActive (false);
		P2IsTheWinner.gameObject.SetActive (false);
		Tie.gameObject.SetActive (false);
		
	}
	void WinConditions(){
		if (P1IsTheWinner && !P2IsTheWinner) {
			P1IsTheWinner.gameObject.SetActive (true);
		} else if (!P1IsTheWinner && P2IsTheWinner) {
			P2IsTheWinner.gameObject.SetActive (true);
		} else if (P1IsTheWinner && P2IsTheWinner) {
			Tie.gameObject.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		WinConditions ();
		
	}
}
