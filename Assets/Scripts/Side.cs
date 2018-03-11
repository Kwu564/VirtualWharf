using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour {
    public List<GameObject> tiles;
    // Use this for initialization
    void Awake()
    {
        if (GlobalData.markers == null)
        {
            DontDestroyOnLoad(gameObject);
            GlobalData.markers = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (Transform child in transform)
        {
            tiles.Add(child.gameObject);
        }
    }
    void Start () {
        
		
        //tiles.Reverse();
        //print(tiles[3].name);
	}
	
    public GameObject NextTile(int pos)
    {
        return tiles[pos%tiles.Count];
    }
    public int UpZ(GameObject first,GameObject second)
    {
        return (int)(first.transform.position.z - second.transform.position.z);
    }
}
