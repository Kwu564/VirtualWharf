using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalScore : MonoBehaviour {
    public List<Image> Trophies;
    public int player;
    private int i = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
		foreach(GameObject trophy in GlobalData.Inventory[player])
        {
            Trophies[i].enabled = true;
            Trophies[i].sprite = trophy.GetComponent<SpriteRenderer>().sprite;
            i++;
        }
        i = 0;
	}
}
