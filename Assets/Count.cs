using System.Collections;
using UnityEditor.Animations;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Count : MonoBehaviour {
	public Animation CountdownAnim;
	public bool AnimShows;
	public bool TimeStops;
	public GameObject CountdownGameObj;
	public Text timer;
	public PauseMenu pause;
	// Use this for initialization
	void Start () {
		CheckIfAnimShows ();
		CountdownGameObj.SetActive (true);
		CountdownAnim = CountdownGameObj.GetComponent<Animation> ();
		pause.enabled = false;
		StartCoroutine ("Freeze");
	}
	IEnumerator Freeze(){
		yield return new WaitForEndOfFrame();
		Time.timeScale = 0.0f;
		int time = 3;
		while (time>0) {
			timer.text = time.ToString();
			yield return new WaitForSecondsRealtime (1f);
			time--;
		}
		timer.text = "GO!";
		yield return new WaitForSecondsRealtime(.9f);
		timer.text = "";
		Time.timeScale = 1f;
		pause.enabled = true;

	}


	void CheckIfAnimShows(){
		if(CountdownAnim.IsPlaying("Countdown")){
			AnimShows = true;
		}
		else if(!CountdownAnim.IsPlaying("Countdown")){
			AnimShows = false;
		}
	}
	// Update is called once per frame
	void Update () {
	}
}
