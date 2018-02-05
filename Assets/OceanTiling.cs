using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanTiling : MonoBehaviour {
    [HideInInspector] // Hides the variable below from the Inspector
    public Transform tile;
    [HideInInspector]
    public Transform newChild;
    public int length;
	// Use this for initialization
	void Start () {
        // Assigns transform of the first child of the Game Object this script is attached to
        tile = this.gameObject.transform.GetChild(0);
        for (int i = 1; i < length; i++)
        {
            for (int j = 1; j < length; j++)
            {
                // The first tile already exists so skip it
                if (i * 50 - 25 == 25 && j * 50 - 25 == 25)
                {
                    // Do nothing
                } else
                {
                    newChild = Instantiate(tile, new Vector3(0, 0, 0), Quaternion.identity);
                    newChild.transform.parent = gameObject.transform;
                    newChild.transform.localPosition = new Vector3(i * 50 - 25, 0, j * 50 - 25);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
