using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour {
    public List<GameObject> tiles;
    // Use this for initialization
    void Start () {
		foreach(Transform child in transform)
        {
            tiles.Add(child.gameObject);
        }
        //tiles.Reverse();
        //print(tiles[3].name);
	}
	
    public Vector3 NextTile(int pos)
    {
        return tiles[pos%tiles.Count].transform.position;
    }
    public int UpZ(GameObject first,GameObject second)
    {
        return (int)(first.transform.position.z - second.transform.position.z);
    }
}
