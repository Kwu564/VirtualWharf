using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenuButtonClicks : MonoBehaviour {
	public Button ResumeButton;
	public Button ReturnToTitleButton;
	public Button QuitButton;
	

	// Use this for initialization
	void Start () {
		ResumeButton.onClick.AddListener (OnResumeClick);
		ReturnToTitleButton.onClick.AddListener (OnReturnToTitleOnClick);
		QuitButton.onClick.AddListener (OnQuitClick);
		
	}
	public void OnResumeClick(){
		GameObject.Find("Main Camera").GetComponent<PauseMenu> ().pauseMenuShows = false;
	}
	public void OnReturnToTitleOnClick(){
		GameObject.Find("Main Camera").GetComponent<PauseMenu> ().pauseMenuShows = false;
		SceneManager.LoadScene ("MainMenu");
	}
	public  void OnQuitClick(){
		Application.Quit ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
