using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCandyBoxMovement : MonoBehaviour {
	public float Speed;
	private Rigidbody2D CandyBox;
	private SpriteRenderer SRenderer;
	public Image CandyBoxMeter;


	public int CandyCounter;
	public Sprite RedLicoriceWheelBox;
	public Sprite LicoricePastelsBox;
	public Sprite DarkChocolateRockyRoadBitsBox;
	public Sprite PeachyOsBox;
	public Sprite SaltWaterTaffyBox;

	// Use this for initialization
	void Start () {
		CandyBox=gameObject.GetComponent<Rigidbody2D> ();
		CandyCounter = 0;
		CandyBoxMeter.fillAmount = 0f;
		SRenderer = GetComponent<SpriteRenderer> ();
		SRenderer.sprite = RedLicoriceWheelBox;
	}
	
	// Update is called once per frame
	void Update () {
		MoveBackAndForth ();
		if (CandyCounter == 30 && SRenderer.sprite==RedLicoriceWheelBox) {
			SRenderer.sprite = LicoricePastelsBox;
			CandyCounter = 0;
		}
		if (CandyCounter == 35 && SRenderer.sprite == LicoricePastelsBox) {
			SRenderer.sprite = DarkChocolateRockyRoadBitsBox;
			CandyCounter = 0;
		}
		if (CandyCounter == 20 && SRenderer.sprite == DarkChocolateRockyRoadBitsBox) {
			SRenderer.sprite = PeachyOsBox;
			CandyCounter = 0;
		}
		if (CandyCounter == 25 && SRenderer.sprite == PeachyOsBox) {
			SRenderer.sprite = SaltWaterTaffyBox;
			CandyCounter = 0;
		}
		if (CandyCounter == 40 && SRenderer.sprite == SaltWaterTaffyBox) {
			Time.timeScale = 0;
			print ("You Win!");
		}
		
	}
	void MoveBackAndForth(){
		if (Input.GetKey ("left")) {
			Vector2 Move = new Vector2 (-1, 0);
			Move = Move * Speed*Time.deltaTime;
			CandyBox.velocity = Move;

		}
		else if (Input.GetKey ("right")) {
			Vector2 Move = new Vector2 (1, 0);
			Move = Move * Speed * Time.deltaTime;
			CandyBox.velocity = Move;

		} else {
			CandyBox.velocity = Vector2.zero;
		}
	}
	void OnCollisionEnter2D(Collision2D Col){
		if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag == "RedLicoriceWheels") && (SRenderer.sprite == RedLicoriceWheelBox)) {
			CandyCounter += 1;
			CandyBoxMeter.fillAmount += 0.5f;
			Destroy (Col.gameObject);
		} else if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag != "RedLicoriceWheels") && (SRenderer.sprite == RedLicoriceWheelBox)) {
			CandyCounter = 0;
			CandyBoxMeter.fillAmount = 0f;
			Destroy (Col.gameObject);
		}
		if ( (Col.gameObject.tag != "Player") && (Col.gameObject.tag == "LicoricePastels") && (SRenderer.sprite== LicoricePastelsBox) ){
			CandyCounter += 1;
			Destroy (Col.gameObject);
		} else if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag != "LicoricePastels") && (SRenderer.sprite == LicoricePastelsBox)) {
			CandyCounter = 0;
			Destroy (Col.gameObject);
		}
		if ( (Col.gameObject.tag != "Player") && (Col.gameObject.tag == "DarkChocolateRockyRoadBites") && (SRenderer.sprite == DarkChocolateRockyRoadBitsBox) ){
			CandyCounter += 1;
			Destroy (Col.gameObject);
		} else if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag != "DarkChocolateRockyRoadBites") && (SRenderer.sprite == DarkChocolateRockyRoadBitsBox)) {
			CandyCounter = 0;
			Destroy (Col.gameObject);
		}
		if ( (Col.gameObject.tag != "Player") && (Col.gameObject.tag == "PeachyOs") && (SRenderer.sprite== PeachyOsBox) ){
			CandyCounter += 1;
			Destroy (Col.gameObject);
		} else if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag != "PeachyOs") && (SRenderer.sprite == PeachyOsBox)) {
			CandyCounter = 0;
			Destroy (Col.gameObject);
		}
		if ( (Col.gameObject.tag != "Player") && (Col.gameObject.tag == "SaltWaterTaffy") && (SRenderer.sprite== SaltWaterTaffyBox) ){
			CandyCounter += 1;
			Destroy (Col.gameObject);
		} else if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag != "SaltWaterTaffy") && (SRenderer.sprite == SaltWaterTaffyBox)) {
			CandyCounter = 0;
			Destroy (Col.gameObject);
		}
		
	}
}
