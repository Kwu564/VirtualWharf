using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour {
	private float speed;
//	public float thrust;

//	public Rigidbody2D rb2d;

	void Start(){
	//	rb2d = GetComponent<Rigidbody2D> ();
		speed = 110;
	}

	void Update()
	{

			
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float jumpUp = Input.GetAxis ("Jump");
	//	rb2d.AddForce (transform.up * thrust);
	//	rb2d.AddForce (new Vector3 (0, 10), ForceMode2D.Impulse);
		transform.Translate (new Vector2 (moveHorizontal, moveVertical) * Time.deltaTime * speed);
	//	Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		//rb2d.AddForce (movement * speed);
	}
}


	/*void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
	}
	*/

