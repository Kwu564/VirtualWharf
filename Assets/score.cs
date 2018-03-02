using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour {
    public int player;
	public Image FailIcon;
	public Image SucceedIcon;
	// Use this for initialization
	void Start () {
		SucceedIcon.enabled = false;
		FailIcon.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.GetComponent<Text>().text = Minigame3Data.Scores[player,Minigame3Data.round].ToString();
		if (Minigame3Data.Scores [player,Minigame3Data.round] == 900 && Minigame3Data.Checked[player, Minigame3Data.round] == 9) {
			SucceedIcon.enabled = true;
            //print("Win");
			gameObject.GetComponent<Text> ().text = "You win!";
		} else if (Minigame3Data.Checked[player, Minigame3Data.round] == 9) {
            //print("Lose");
            FailIcon.enabled = true;
		}
	}
}
