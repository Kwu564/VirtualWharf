using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMove : MonoBehaviour {
    public int current = 0;
    private int steps = 1;
    public float speed = 1;
    private Side map;
    public GameObject wharf;
	// Use this for initialization
	void Start () {
        map = wharf.GetComponent<Side>();
	}
	
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            steps = (int)Random.Range(1, 6);
            Debug.Log(steps);
            move();
        }
        
        

    }
	// Update is called once per frame
	void move () {
        Vector3 End = map.NextTile(current + 1);
        while (Vector3.Distance(transform.position,End) > .0001)
        {
            transform.position = Vector3.MoveTowards(transform.position, End, speed * Time.deltaTime);
        }
        current = current + 1;
        steps--;
        if (steps > 0)
        {
            Invoke("move", 1f);
        }
    }
}
