using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using Rewired;
public class PlayerCandyBoxMovement : MonoBehaviour {
	public float Speed;
	public GameObject RedLicoriceWheelUI;
	public GameObject LicoricePastelUI;
	public GameObject DarkChocolateRockyRoadBitsUI;
	public GameObject PeachyOsUI;
	public GameObject SaltWaterTaffyUI;
	private Rigidbody2D CandyBox;
	private Image SRenderer;
	public Image CandyBoxMeter;
    public int id;
    public Text winner;
    public Player player;
    public int CandyCounter;
	public Sprite RedLicoriceWheelBox;
	public Sprite LicoricePastelsBox;
	public Sprite DarkChocolateRockyRoadBitsBox;
	public Sprite PeachyOsBox;
	public Sprite SaltWaterTaffyBox;
    public GameObject trophy;
	public PauseMenu pause;    
	// Use this for initialization
	void Start () {
        player = ReInput.players.GetPlayer(id);
        CandyBox =gameObject.GetComponent<Rigidbody2D> ();
		CandyCounter = 0;
		CandyBoxMeter.fillAmount = 0f;
		SRenderer = GetComponent<Image> ();
		SRenderer.sprite = RedLicoriceWheelBox;
		RedLicoriceWheelUI.gameObject.SetActive (true);
		LicoricePastelUI.gameObject.SetActive (false);
		DarkChocolateRockyRoadBitsUI.gameObject.SetActive (false);
		PeachyOsUI.gameObject.SetActive (false);
		SaltWaterTaffyUI.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		CurrentUICandy ();
		MoveBackAndForth ();
		if (CandyCounter == 3 && SRenderer.sprite==RedLicoriceWheelBox) {
			SRenderer.sprite = LicoricePastelsBox;
            CandyBoxMeter.fillAmount = 0;
            CandyCounter = 0;
		}
		if (CandyCounter == 4 && SRenderer.sprite == LicoricePastelsBox) {
			SRenderer.sprite = DarkChocolateRockyRoadBitsBox;
            print("Changed");
            CandyBoxMeter.fillAmount = 0;
            CandyCounter = 0;
		}
		if (CandyCounter == 2 && SRenderer.sprite == DarkChocolateRockyRoadBitsBox) {
			SRenderer.sprite = PeachyOsBox;
            CandyBoxMeter.fillAmount = 0;
            CandyCounter = 0;
		}
		if (CandyCounter == 3 && SRenderer.sprite == PeachyOsBox) {
			SRenderer.sprite = SaltWaterTaffyBox;
            CandyBoxMeter.fillAmount = 0;
            CandyCounter = 0;
		}
		if (CandyCounter == 1 && SRenderer.sprite == SaltWaterTaffyBox) {
            //Time.timeScale = 0;
            if (Time.timeScale > 0)
            {
                StartCoroutine("Pause");
            }
            //print(Time.timeScale);
			winner.text = "Player "+(id+1)+" Win!";
            if (!GlobalData.Inventory[id].Contains(trophy))
            {
                GlobalData.Inventory[id].Add(trophy);
            }
            GlobalData.MinigameWinner = id;
            SceneManager.LoadScene("sceneOne");
		}
		
	}
	void MoveBackAndForth(){
        /*if (Input.GetKey ("left")) {
			Vector2 Move = new Vector2 (-1, 0);
			Move = Move * Speed*Time.deltaTime;
			CandyBox.velocity = Move;

		}
		else if (Input.GetKey ("right")) {
			Vector2 Move = new Vector2 (1, 0);
			Move = Move * Speed * Time.deltaTime;
			CandyBox.velocity = Move;
		}*/
        Vector2 Move = new Vector2(player.GetAxis("Move"),player.GetAxis("MoveY"));
        if(Move != Vector2.zero)
        {
            Move = Move * Speed * Time.deltaTime;
            print(Time.deltaTime);
            CandyBox.velocity = Move;
        }else {
			CandyBox.velocity = Vector2.zero;
		}
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
    }
	void OnCollisionEnter2D(Collision2D Col){
		if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag == "RedLicoriceWheels") && (SRenderer.sprite == RedLicoriceWheelBox)) {
			CandyCounter += 1;
			CandyBoxMeter.fillAmount += (1f/3f);
			Destroy (Col.gameObject);
		} else if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag != "RedLicoriceWheels") && (SRenderer.sprite == RedLicoriceWheelBox)) {
			CandyCounter = 0;
			CandyBoxMeter.fillAmount = 0;
			Destroy (Col.gameObject);
		}
		if ( (Col.gameObject.tag != "Player") && (Col.gameObject.tag == "LicoricePastels") && (SRenderer.sprite== LicoricePastelsBox) ){
			CandyCounter += 1;
            CandyBoxMeter.fillAmount += (1f / 4f);
            Destroy (Col.gameObject);
		} else if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag != "LicoricePastels") && (SRenderer.sprite == LicoricePastelsBox)) {
			CandyCounter = 0;
            CandyBoxMeter.fillAmount = 0;
            Destroy (Col.gameObject);
		}
		if ( (Col.gameObject.tag != "Player") && (Col.gameObject.tag == "DarkChocolateRockyRoadBits") && (SRenderer.sprite == DarkChocolateRockyRoadBitsBox) ){
			CandyCounter += 1;
            print("hit");
            CandyBoxMeter.fillAmount += (1f / 2f);
            Destroy (Col.gameObject);
		} else if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag != "DarkChocolateRockyRoadBits") && (SRenderer.sprite == DarkChocolateRockyRoadBitsBox)) {
			CandyCounter = 0;
            CandyBoxMeter.fillAmount = 0;
            print("miss");
            Destroy (Col.gameObject);
		}
		if ( (Col.gameObject.tag != "Player") && (Col.gameObject.tag == "PeachyOs") && (SRenderer.sprite== PeachyOsBox) ){
			CandyCounter += 1;
            CandyBoxMeter.fillAmount += (1f/3f);
            Destroy (Col.gameObject);
		} else if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag != "PeachyOs") && (SRenderer.sprite == PeachyOsBox)) {
			CandyCounter = 0;
            CandyBoxMeter.fillAmount = 0;
            Destroy (Col.gameObject);
		}
		if ( (Col.gameObject.tag != "Player") && (Col.gameObject.tag == "SaltWaterTaffy") && (SRenderer.sprite== SaltWaterTaffyBox) ){
			CandyCounter += 1;
            CandyBoxMeter.fillAmount += 1f;
            Destroy (Col.gameObject);
		} else if ((Col.gameObject.tag != "Player") && (Col.gameObject.tag != "SaltWaterTaffy") && (SRenderer.sprite == SaltWaterTaffyBox)) {
			CandyCounter = 0;
            CandyBoxMeter.fillAmount = 0;
            Destroy (Col.gameObject);
		}
		
	}
    IEnumerator Pause()
    {
		pause.enabled = false;
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("sceneOne");
        StopAllCoroutines();
        
    }
	void CurrentUICandy(){
		if (SRenderer.sprite == LicoricePastelsBox) {
			RedLicoriceWheelUI.gameObject.SetActive (false);
			LicoricePastelUI.gameObject.SetActive (true);
		} else if (SRenderer.sprite == DarkChocolateRockyRoadBitsBox) {
			LicoricePastelUI.gameObject.SetActive (false);
			DarkChocolateRockyRoadBitsUI.gameObject.SetActive (true);
		} else if (SRenderer.sprite == PeachyOsBox) {
			DarkChocolateRockyRoadBitsUI.gameObject.SetActive (false);
			PeachyOsUI.gameObject.SetActive (true);
		} else if (SRenderer.sprite == SaltWaterTaffyBox) {
			PeachyOsUI.gameObject.SetActive (false);
			SaltWaterTaffyUI.gameObject.SetActive (true);
		}
	}
}
