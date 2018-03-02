using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour {
    public int player, round;
	public Image FailIcon;
	public Image SucceedIcon;
	// Use this for initialization
	void Start () {
		SucceedIcon.enabled = false;
		FailIcon.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = Minigame3Data.Scores[player,round].ToString();
		if (Minigame3Data.Scores [player, round] == 900) {
			SucceedIcon.enabled = true;
			gameObject.GetComponent<Text> ().text = "You win!";
		} else if (Minigame3Data.Scores [player, round] != 900 && Time.deltaTime==0) {
			FailIcon.enabled = true;
		}
	}
}
