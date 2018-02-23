using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject candy;
	public float spawnTime = 4f;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn",0f, spawnTime);
	}

	// Update is called once per frame
	void Spawn () {
		float x = Random.Range(-30.0f, 30f);
		//float y = Random.Range(0f, 9.0f);
		Instantiate(candy, new Vector3(x, 9.0f, 0),Quaternion.Euler(0f,0f,0f));
	}
}
