using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
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
    private Player player;
    [SerializeField]
    private int id;
    // Use this for initialization
    void Awake()
    {
        if (GlobalData.players[id] == null)
        {
            DontDestroyOnLoad(gameObject);
            GlobalData.players[id] = gameObject;
        }else
        {
            Destroy(gameObject);
        }
        
    }
    void Start () {
       // map = wharf.GetComponent<Side>();
        //End = transform.position;
        //player = ReInput.players.GetPlayer(0);
        //GlobalData.turn++;
    }
    void OnEnable()
    {
        map = wharf.GetComponent<Side>();
        End = transform.position;
        player = ReInput.players.GetPlayer(id);
       
    }
    void Update()
    {
        if (moving && Vector3.Distance(transform.position, End) > smoothing)
        {
            transform.position = Vector3.MoveTowards(transform.position, End, speed * Time.deltaTime);
        }
        else if (moving)
        {
            GlobalData.turn++;
            print("End of player turn");
            print(OtherPlayer.GetComponent<TileMove>());
            map.NextTile(current).GetComponent<Minigame>().enterGame();
            //cam.GetComponent<CameraFollow>().target = OtherPlayer.transform;
            //OtherPlayer.GetComponent<TileMove>().enabled = true;
            //map.NextTile(current);
            moving = false;
        }
        if (player.GetButtonDown("action"))
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
        int motorIndex = 0; // the first motor
        float motorLevel = 1.0f; // full motor speed
        float duration = 2.0f; // 2 seconds
        //player.SetVibration(motorIndex, motorLevel, duration);
        End = map.NextTile(current + steps).transform.position;
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
