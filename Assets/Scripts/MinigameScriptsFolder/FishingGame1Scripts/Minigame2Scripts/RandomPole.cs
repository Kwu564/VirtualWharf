using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using Rewired;
using UnityEngine.SceneManagement;
public class RandomPole : MonoBehaviour {
    public GameObject[] Poles;
	public GameObject Pole1AnimObj;
	private Animation Pole1Anim;

	public GameObject Pole2AnimObj;
	private Animation Pole2Anim;

	public GameObject Pole3AnimObj;
	private Animation Pole3Anim;

	public GameObject Pole4AnimObj;
	private Animation Pole4Anim;

    public GameObject Trophy;

    public bool[] SelectedPole = {false,false};
    public int RandomizedValue;
    public int WinningRod;
    public bool check;
    public bool set;
    private Player PlayerOne;
    private Player PlayerTwo;
    public int P1Rod = 4;
    public int P2Rod = 4;
    // Fill these values with fish?
    public List<GameObject> SelectedFish;

    //Fish popup
    public GameObject popup;
    public Text FishName;
    public Image FishImg;
    public Text WinnerName;

    public Text[] Exclam;
    // Use this for initialization
    void Start () {
		Pole1Anim = Pole1AnimObj.GetComponent<Animation> ();
		Pole2Anim = Pole2AnimObj.GetComponent<Animation> ();
		Pole3Anim = Pole3AnimObj.GetComponent<Animation> ();
		Pole4Anim = Pole4AnimObj.GetComponent<Animation> ();

        PlayerOne = ReInput.players.GetPlayer(0);
        PlayerTwo = ReInput.players.GetPlayer(1);
        set = false;
        WinningRod = (int)Random.Range(0f,3f);
        StartCoroutine("showWinner");
    }
    void ConditionsOfPole()
    {
        StopCoroutine("showWinner");


        //Stop all animations 
        if (WinningRod == 0)
        {
            //Pole1Anim["Pole1Animation"].speed = -0.6666667f;
            Pole1Anim["Pole1Animation"].time = 0f;
            Pole1Anim.Sample();
            Pole1Anim.Stop();
        }
        else if (WinningRod == 1)
        {
            //Pole2Anim["Pole1Animation"].speed = -0.6666667f;
            Pole2Anim["Pole1Animation"].time = 0f;
            Pole2Anim.Sample();
            Pole2Anim.Stop();

        }
        else if (WinningRod == 2)
        {
            //Pole3Anim["Pole1Animation"].speed = -0.6666667f;
            Pole3Anim["Pole1Animation"].time = 0f;
            Pole3Anim.Sample();
            Pole3Anim.Stop();

        }
        else if (WinningRod == 3)
        {
            //Pole4Anim["Pole1Animation"].speed = -0.6666667f;
            Pole4Anim["Pole1Animation"].time = 0f;
            Pole3Anim.Sample();
            Pole4Anim.Stop();
        }
    
        Exclam[WinningRod].gameObject.SetActive(false);
        // Show fish here
        
        StartCoroutine("Info");
        
        //P1Rod = -1;
        //P2Rod = -1;
        set = false;
        SelectedPole[1] = false;
        SelectedPole[0] = false;
        WinningRod = (int)Random.Range(0f, 3f);
        StartCoroutine("showWinner");
    }

    IEnumerator showWinner()
    {

        float wait = Random.Range(1,3);
        yield return new WaitForSeconds(wait);
		//if (set) {
//			Pole1Anim ["Pole1Animation"].speed = 0.6666667f;
//			Pole1Anim.Play ();
	//	}
		/*} else if (!set) {
			Pole1Anim["Pole1Animation"].time = 0f;
		}
		*/
        /*if(P1Rod == WinningRod)
        {
            ConditionsOfPole();

        }
        else if(P2Rod == WinningRod){
            ConditionsOfPole();
            
        }*/
        foreach(Text mark in Exclam)
        {
            mark.gameObject.SetActive(false);
        }
      

		if (WinningRod == 0) {
			Pole1Anim ["Pole1Animation"].speed = 0.6666667f;
			Pole1Anim.Play ();
		} else if (WinningRod == 1) {
			Pole2Anim ["Pole1Animation"].speed = 0.6666667f;
			Pole2Anim.Play ();
		
		} else if (WinningRod == 2) {
			Pole3Anim ["Pole1Animation"].speed = 0.6666667f;
			Pole3Anim.Play ();
	
		} else if (WinningRod == 3) {
			Pole4Anim ["Pole1Animation"].speed = 0.6666667f;
			Pole4Anim.Play ();
		} 
	    	
        float motorLevel = 1.00f; // full motor speed
        float duration = 1.1f; // 2 seconds
        PlayerOne.SetVibration(0,motorLevel, duration);
        PlayerOne.SetVibration(1,motorLevel, duration);
        PlayerTwo.SetVibration(0, motorLevel, duration);
        PlayerTwo.SetVibration(1, motorLevel, duration);
        Exclam[WinningRod].gameObject.SetActive(true);
        set = true;
    }

    IEnumerator Info()
    {
        Time.timeScale = 0f;
        
        GameObject RandomizedVal = SelectedFish[Mathf.RoundToInt(Random.Range(0f, (float)SelectedFish.Count-1))];
        popup.SetActive(true);
        FishName.text = RandomizedVal.name;
        FishImg.sprite = RandomizedVal.GetComponent<Image>().sprite;
        if (P1Rod == WinningRod)
        {
            WinnerName.text = "Player 1 caught";
            print("Player1 won!");
            MiniGame2Data.player1Fish += 1;
        }
        else if(P2Rod == WinningRod)
        {
            WinnerName.text = "Player 2 caught";
            print("Player1 won!");
            MiniGame2Data.player2Fish += 1;
        }
        //P1Rod = -1;
        //P2Rod = -1;
        yield return new WaitForSecondsRealtime(.8f);
        popup.SetActive(false);
        P1Rod = -1;
        P2Rod = -1;
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update () {
        if (SelectedPole[0] == false)
        {
            if (PlayerOne.GetButton("FirstPole") && P2Rod != 0){
                P1Rod = 0;
                print(P1Rod);
                //SelectedPole[0]=true;
            }
            else if (PlayerOne.GetButton("SecPole") && P2Rod != 1){
                P1Rod = 1;
                print(P1Rod);
                //SelectedPole[0] = true;
            }
            else if (PlayerOne.GetButton("ThirdPole") && P2Rod != 2){
                P1Rod = 2;
                print(P1Rod);
                //SelectedPole[0] = true;
            }
            else if (PlayerOne.GetButton("FourthPole") && P2Rod != 3){
                P1Rod = 3;
                print(P1Rod);
                //SceneManager.LoadScene("sceneOne");
                //SelectedPole[0] = true;
            }
        }
        if (SelectedPole[1] == false)
        {
            if (PlayerTwo.GetButton("FirstPole") && P1Rod != 0)
            {
                P2Rod = 0;
                print(P2Rod);
                //SelectedPole[1] = true;
            }
            else if (PlayerTwo.GetButton("SecPole") && P1Rod != 1)
            {
                P2Rod = 1;
                print(P2Rod);
                //SelectedPole[1] = true;
            }
            else if (PlayerTwo.GetButton("ThirdPole") && P1Rod != 2)
            {
                P2Rod = 2;
                print(P2Rod);
                //SelectedPole[1] = true;
            }
            else if (PlayerTwo.GetButton("FourthPole") && P1Rod != 3)
            {
                P2Rod = 3;
                print(P2Rod);
                //SelectedPole[1] = true;
            }
        }
        if ( (P1Rod==WinningRod || P2Rod == WinningRod) && set)
        {
            SelectedPole[1] = true;
            SelectedPole[0] = true;
            ConditionsOfPole();
            

        }
    }

    public void OnDisable()
    {
        StopAllCoroutines();
        if (MiniGame2Data.player1Fish > MiniGame2Data.player2Fish)
        {
            //GlobalData.Inventory[0].Add();
            if (!GlobalData.Inventory[0].Contains(Trophy))
            {
                GlobalData.Inventory[0].Add(Trophy);
                GlobalData.MinigameWinner = 0;
            }
            
        }
        else if(MiniGame2Data.player1Fish < MiniGame2Data.player2Fish)
        {
            if (!GlobalData.Inventory[1].Contains(Trophy))
            {
                GlobalData.Inventory[1].Add(Trophy);
                GlobalData.MinigameWinner = 1;
            }
            
        }
        SceneManager.LoadSceneAsync("sceneOne");
    }
}
