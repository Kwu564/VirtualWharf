using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour {
    public int player, round;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = Minigame3Data.Scores[player,round].ToString();
        if (Minigame3Data.Scores[player,round] == 900)
        {
            gameObject.GetComponent<Text>().text = "You win!";
        }
	}
}
