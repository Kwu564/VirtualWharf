using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour {
    public int player;
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
	public CircleCollider2D IngredientCollider;
	public CircleCollider2D StickCollider;
	public Camera cam;
    public Canvas cafe;
	// Use this for initialization
	void Start () {
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
			StartingPosition = this.transform.localPosition.x;
			EndingPosition = this.transform.localPosition.x + cam.pixelWidth;
		} else {
			EndingPosition = this.transform.localPosition.x - cam.pixelWidth;
			StartingPosition = this.transform.localPosition.x;
			StartX = StartingPosition;
		}

	}
	private void CheckForCollisions(){
		if (IngredientCollider.IsTouching (StickCollider)) {
			print ("PLUS 1");
            Minigame3Data.Scores[player,Minigame3Data.round] += 100;
            HasCollided = true;
		}
        Minigame3Data.Checked[player, Minigame3Data.round] += 1;
        print("player:"+player+" " + Minigame3Data.Checked[player,0]);
    }
	void StopMovement(){
		if (Input.GetKeyDown ("space")) {
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
