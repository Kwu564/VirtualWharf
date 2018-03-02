using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColliders : MonoBehaviour {
    public Transform tile;
    public int length;
    public float Xoffset;
    public Transform newChild;
	// Use this for initialization
	void Start () {
        tile = this.gameObject.transform.GetChild(0);

        for(int i = 1; i < length; i++)
        {
            newChild = Instantiate(tile,tile.localPosition, Quaternion.identity);
            newChild.transform.parent = gameObject.transform;
            newChild.transform.position = tile.position;
            newChild.transform.Translate(-i*Xoffset,0,0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
