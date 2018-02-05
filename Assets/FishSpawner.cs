using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {
    public GameObject fish;
    public float spawnTime = 4f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn",0f, spawnTime);
    }
	
	// Update is called once per frame
	void Spawn () {
        float x = Random.Range(7f, 8f);
        float y = Random.Range(-1.2f, .7f);
        Instantiate(fish, new Vector3(x, y, 0),Quaternion.Euler(0f,0f,0f));
	}
}
