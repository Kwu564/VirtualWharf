using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour {
	public List<Sprite> type;
	// Use this for initialization
	void Awake () {
		int rand = Mathf.RoundToInt (Random.Range (0, type.Count));
		gameObject.GetComponent<SpriteRenderer> ().sprite = type [rand];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
