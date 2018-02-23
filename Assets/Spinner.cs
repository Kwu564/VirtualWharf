using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spinner : MonoBehaviour {
    private Image icon;
    private int index;
	// Use this for initialization
	void Start () {
        index = 0;
        icon = gameObject.GetComponent<Image>();
        //icon.sprite = GlobalData.Inventory[0][index].GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("l") && GlobalData.Inventory[0].Count != 0)
        {
            index = (index +1)% GlobalData.Inventory[0].Count;
            icon.sprite = GlobalData.Inventory[0][index].GetComponent<SpriteRenderer>().sprite;
        }
	}
}
