using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour {
	public Button Play;
	public Button Credits;
	public Button Quit;
	// Use this for initialization
	void Start () {
		Play.onClick.AddListener (GoToGame);
		Credits.onClick.AddListener (GoToCredits);
		Quit.onClick.AddListener (GoToQuit);
	}
	public void GoToGame(){
		SceneManager.LoadScene ("sceneOne");
	}
	public void GoToCredits(){
		SceneManager.LoadScene ("CreditsPage");
	}
	public void GoToQuit(){
		Application.Quit ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
