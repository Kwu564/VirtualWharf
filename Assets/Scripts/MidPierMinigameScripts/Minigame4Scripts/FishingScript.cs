using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingScript : MonoBehaviour {
	public bool casted;
	public bool FishIsOnLine;
	public bool CatchingOneFishAtATime;
	public bool FishIsCaught;
	public bool StillFishing;

	// Use this for initialization
	void Start () {
		casted = false;
		CatchingOneFishAtATime = false;
		FishIsOnLine = false;
		FishIsCaught = false;
		StillFishing = false;

	}
	IEnumerator WaitForFishToBeCaughtOnLine(){
		//FishIsOnLine = true;
		print ("Wait for it...");
		yield return new WaitForSeconds (5);
		FishIsOnLine = true;
		print ("Fish is on the line!");
	}
	void CheckIfMousePressed(){
		if (Input.GetMouseButtonDown (0)) {
			casted = !casted;
			FishIsOnLine = false;
			FishIsCaught = false;
			if (casted) {
				print ("Casted");
				//FishIsOnLine = false;
				StartCoroutine ("WaitForFishToBeCaughtOnLine");
				FishIsCaught = false;
			} else if (!casted) {
				print ("Not casted");
				StopCoroutine ("WaitForFishToBeCaughtOnLine");
				StillFishing = false;
				FishIsOnLine = false;
				FishIsCaught = false;
			}
		}
		if (Input.GetKeyDown("space") && casted && FishIsOnLine && !FishIsCaught) {
			FishIsCaught = true;
			print ("Fish caught");
			casted = false;
		}
	}
	// Update is called once per frame
	void Update () {
		CheckIfMousePressed ();
	}
}
