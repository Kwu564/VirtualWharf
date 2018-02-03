using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMove : MonoBehaviour {
    public int current = 0;
    private int steps = 1;
    public float speed = 1;
    public float smoothing;
    private Side map;
    public GameObject cam;
    public GameObject wharf;
    public GameObject OtherPlayer;
    public Vector3 End;
    private bool moving;
    // Use this for initialization
    void Start () {
        map = wharf.GetComponent<Side>();
        End = transform.position;
	}

    void Update()
    {
        if (moving && Vector3.Distance(transform.position, End) > smoothing)
        {
            transform.position = Vector3.MoveTowards(transform.position, End, speed * Time.deltaTime);
        }else if (moving)
        {
            print("End of player turn");
            print(OtherPlayer.GetComponent<TileMove>());
            cam.GetComponent<CameraFollow>().target = OtherPlayer.transform;
            OtherPlayer.GetComponent<TileMove>().enabled = true;
            this.enabled = false;
            moving = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            steps = (int)Random.Range(1, 6);
            Debug.Log(steps);
            //target = map.NextTile(current + steps);
            //current = current + steps;
            //print(target);
            move();
        }
    }
	// Update is called once per frame
	void move () {
        if (moving)
        {
            return;
        }
        End = map.NextTile(current + steps);
        moving = true;
        current = current + steps;
        /*while (Vector3.Distance(transform.position,End) > .0001)
        {
            transform.position = Vector3.MoveTowards(transform.position, End, speed * Time.deltaTime);
        }*/
       // current = current + 1;
        //steps--;
        /*if (steps > 0)
        {
            Invoke("move", 1f);
        }*/
    }
}
