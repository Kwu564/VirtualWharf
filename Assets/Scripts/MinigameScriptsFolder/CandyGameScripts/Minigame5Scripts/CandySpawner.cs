using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject candy;
	public List<GameObject> candies = new List<GameObject> ();
	public float spawnTime;
	public float lowX;
	public float highX;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn",0f, spawnTime);
	}

	// Update is called once per frame
	void Spawn () {
		float x = Random.Range(lowX,highX);
		int index = (int)Random.Range (0f, (float)candies.Count);
		//float y = Random.Range(0f, 9.0f);
		Instantiate(candies[index], new Vector3(x, 9.0f, 0),Quaternion.Euler(0f,0f,0f));
	}
}
