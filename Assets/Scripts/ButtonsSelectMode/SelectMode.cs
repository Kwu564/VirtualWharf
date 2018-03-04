using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectMode : MonoBehaviour {
	public Button OnePlayer;
	public Button TwoPlayer;

	// Use this for initialization
	void Start () {
		OnePlayer.onClick.AddListener (ToOnePlayerMode);
		TwoPlayer.onClick.AddListener (ToTwoPlayerMode);
	}
	void ToOnePlayerMode(){
		SceneManager.LoadScene ("sceneOne");
	}
	void ToTwoPlayerMode(){
		print ("to scene");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
