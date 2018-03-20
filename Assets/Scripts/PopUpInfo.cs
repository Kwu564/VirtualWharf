using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PopUpInfo : MonoBehaviour {
	public GameObject ThePlayer;
	public Canvas PopUpCanvas;
	public Text LocationText;
	//public int distanceToItem;

	//lifeguard station
	public GameObject LifeGuardBuilding;
	public float DistanceBetweenPlayerAndLifeGuardBuilding;

	// cafe
	public GameObject CafeBuilding;
	public float DistanceBetweenPlayerAndCafeBuilding;

	// souvenir shop
	public GameObject SouvenirBuilding;
	public float DistanceBetweenPlayerAndSouvenirBuilding;

	// kayaks
	public GameObject KayakBuilding;
	public float DistanceBetweenPlayerAndKayakBuilding;

	// fish scaling station
	public GameObject FishScalingStation;
	public float DistanceBetweenPlayerAndFishScalingStation;

	// Use this for initialization
	void Start () {
		PopUpCanvas.gameObject.SetActive (false);
		LocationText.text = (" ");

	}
	void ShowUI(){
		DistanceBetweenPlayerAndLifeGuardBuilding = Vector3.Distance (ThePlayer.transform.position, LifeGuardBuilding.transform.position);
		DistanceBetweenPlayerAndCafeBuilding = Vector3.Distance (ThePlayer.transform.position, CafeBuilding.transform.position);
		DistanceBetweenPlayerAndSouvenirBuilding = Vector3.Distance (ThePlayer.transform.position, SouvenirBuilding.transform.position);
		DistanceBetweenPlayerAndKayakBuilding = Vector3.Distance (ThePlayer.transform.position, KayakBuilding.transform.position);
		DistanceBetweenPlayerAndFishScalingStation = Vector3.Distance (ThePlayer.transform.position, FishScalingStation.transform.position);
		if (DistanceBetweenPlayerAndLifeGuardBuilding <= 10) {
			PopUpCanvas.gameObject.SetActive (true);
			LocationText.text = ("Lifeguard Station");

		} else if (DistanceBetweenPlayerAndCafeBuilding <= 10) {
			PopUpCanvas.gameObject.SetActive (true);
			LocationText.text = ("Woodies Cafe");
		} else if (DistanceBetweenPlayerAndSouvenirBuilding <= 10) {
			PopUpCanvas.gameObject.SetActive (true);
			LocationText.text = ("Souvenir Shop");
		} else if (DistanceBetweenPlayerAndKayakBuilding <= 10) {
			PopUpCanvas.gameObject.SetActive (true);
			LocationText.text = ("Kayak Rental Shop");
		} else if (DistanceBetweenPlayerAndFishScalingStation <= 10) {
			PopUpCanvas.gameObject.SetActive (true);
			LocationText.text = ("Fish Scaling Station");
		} else {
			PopUpCanvas.gameObject.SetActive(false);
		}
	}
	// Update is called once per frame
	void Update () {
		ShowUI ();
	}
}
