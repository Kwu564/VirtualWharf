using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerManager : MonoBehaviour {
    public List<GameObject> burgers;
    public int player;
    public int ingredients;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Minigame3Data.Checked[player, Minigame3Data.round] < ingredients && Time.timeScale>0)
        {
            burgers[Minigame3Data.Checked[player, Minigame3Data.round]].SetActive(true);
        }
	}   
}
