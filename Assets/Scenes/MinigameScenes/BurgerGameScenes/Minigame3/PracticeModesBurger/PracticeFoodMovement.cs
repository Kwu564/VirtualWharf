using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class PracticeFoodMovement : MonoBehaviour {
	public int player;
	public Player controls;
	float XSpeed;
	public float ValueOfXSpeed;
	public float StartingPosition;
	public float EndingPosition;
	private float StartX;
	private float StartY;
	private float StartZ;
	public bool Flip;
	public bool HasCollided;
	private bool check = false;
	public Collider2D IngredientCollider;
	public Collider2D StickCollider;
	public Camera cam;
	public Canvas cafe;
	// Use this for initialization
	void Start () {
		controls = ReInput.players.GetPlayer(player);
		cafe = transform.parent.gameObject.GetComponent<Canvas>();
		HasCollided = false;
		//StickCollider = GameObject.FindGameObjectWithTag ("StickColliderTag").GetComponent<CircleCollider2D> ();
		StartX = transform.localPosition.x;
		StartY = transform.localPosition.y;
		StartZ = transform.localPosition.z;
		/*	XSpeed=3f;
		StartingPosition = 50f;
		EndingPosition=700f;
		StartX=50f;
		StartY=220f;
		StartZ=0f;
		*/
		//QualitySettings.vSyncCount = 0;  // VSync must be disabled or disable in quality manually 
		//Application.targetFrameRate = 60;
		transform.localPosition = new Vector3 (StartX, StartY, StartZ);
		if (!Flip) {
			StartingPosition = this.transform.localPosition.x - cam.pixelWidth;
			EndingPosition = this.transform.localPosition.x + cam.pixelWidth;
		} else {
			EndingPosition = this.transform.localPosition.x - cam.pixelWidth;
			StartingPosition = this.transform.localPosition.x + cam.pixelWidth;
			StartX = StartingPosition;
		}

	}
	private void CheckForCollisions(){
		if (IngredientCollider.IsTouching (StickCollider)) {
			print ("PLUS 1");
			Minigame3Data1.Scores[player,Minigame3Data1.round] += 100;
			print (Minigame3Data1.Scores [player, Minigame3Data1.round]);
			HasCollided = true;
		}
		Minigame3Data1.Checked[player, Minigame3Data1.round] += 1;
		print("player:"+player+" " + Minigame3Data1.Checked[player,Minigame3Data1.round]);
	}
	void StopMovement(){
		if (controls.GetButtonDown("stop")&&!check && Time.timeScale>0) {
			CheckForCollisions ();
			check = true;
		}
		else if(!check)
		{

			transform.localPosition = Vector3.Lerp(new Vector3(StartingPosition, StartY, StartZ), new Vector3(EndingPosition, StartY, StartZ), Mathf.PingPong(Time.time * ValueOfXSpeed, 1));
			transform.localPosition = new Vector3((Mathf.RoundToInt(gameObject.transform.localPosition.x)),
				(Mathf.RoundToInt(gameObject.transform.localPosition.y)),
				(Mathf.RoundToInt(gameObject.transform.localPosition.z)));
		}
		//	CheckForCollisions ();

	}

	// Update is called once per frame
	void Update () {
		StopMovement ();


	}
}
