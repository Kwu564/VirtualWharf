using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class FoodMovement : MonoBehaviour {
	float XSpeed;
	public float ValueOfXSpeed;
	public float StartingPosition;
	public float EndingPosition;
	private float StartX;
	private float StartY;
	private float StartZ;
	public bool Flip;
	public CircleCollider2D IngredientCollider;
	public CircleCollider2D StickCollider;
	// Use this for initialization
	void Start () {
		//StickCollider = GameObject.FindGameObjectWithTag ("StickColliderTag").GetComponent<CircleCollider2D> ();
		StartX = transform.position.x;
		StartY = transform.position.y;
		StartZ = transform.position.z;
        /*	XSpeed=3f;
		StartingPosition = 50f;
		EndingPosition=700f;
		StartX=50f;
		StartY=220f;
		StartZ=0f;
		*/
        //QualitySettings.vSyncCount = 0;  // VSync must be disabled or disable in quality manually 
        //Application.targetFrameRate = 60;
        transform.position = new Vector3 (StartX, StartY, StartZ);
		if (!Flip) {
			StartingPosition = this.transform.position.x;
			EndingPosition = this.transform.position.x + Screen.width;
		} else {
			EndingPosition = this.transform.position.x - Screen.width;
			StartingPosition = this.transform.position.x;
			StartX = StartingPosition;
		}

	}
	private void CheckForCollisions(){
		if (Time.timeScale == 0 && IngredientCollider.IsTouching (StickCollider)) {
			print ("PLUS 1");
			//Destroy (gameObject);
			//StickCollider.enabled = false;
		}
		//IngredientCollider.enabled = false;

	}
	void StopMovement(){
		if (Input.GetKeyDown ("space")) {
			//transform.Translate (0,5f, 0);
			Time.timeScale = 0;
			//IngredientCollider.enabled = false;
			CheckForCollisions ();
		}
	//	CheckForCollisions ();

	}

	// Update is called once per frame
	void Update () {
		StopMovement ();
		//CheckForCollisions ();

		/*if (transform.position.x >= EndingPosition && !Flip) {
			XSpeed = -ValueOfXSpeed;
			//targetPosition = new Vector3(StartingPosition, StartY, StartZ);
		} else if (transform.position.x <= StartingPosition && !Flip) {
			XSpeed=ValueOfXSpeed;
			//targetPosition = new Vector3(EndingPosition, StartY, StartZ);
		}else if (transform.position.x <= EndingPosition && Flip) {
			XSpeed = ValueOfXSpeed;
			//targetPosition = new Vector3(StartingPosition, StartY, StartZ);
		} else if (transform.position.x >= StartingPosition && Flip) {
			XSpeed=-ValueOfXSpeed;
			//targetPosition = new Vector3(EndingPosition, StartY, StartZ);
		}*/
	    //transform.Translate (XSpeed*Time.fixedDeltaTime, 0, 0);

		transform.position = Vector3.Lerp (new Vector3 (StartingPosition, StartY, StartZ), new Vector3 (EndingPosition, StartY, StartZ), Mathf.PingPong (Time.time*ValueOfXSpeed, 1));
			transform.position = new Vector3((Mathf.RoundToInt(gameObject.transform.position.x)),
            (Mathf.RoundToInt(gameObject.transform.position.y)),
            (Mathf.RoundToInt(gameObject.transform.position.z)));
        //Vector3 targetPosition = new Vector3(EndingPosition, StartY, StartZ);

        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, XSpeed*Time.deltaTime);
        //print (transform.position.x);

	}
}
