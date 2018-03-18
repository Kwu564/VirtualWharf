using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class PracticeScoreBurger : MonoBehaviour {
	public int player;

	//public Image FailIcon;
	//public GameObject Current;
	public bool changed = false;
	//public int NextRound;
	public string GoTo;
	public List<GameObject> Fails;
	public List<GameObject> Successes;
	public int Ingredients;
	// Use this for initialization
	void Start () {
		print(Minigame3Data1.Scores[player, Minigame3Data1.round]);
		//Fails = GameObject.FindGameObjectsWithTag("Fail").OrderBy(f => f.name).ToList();
		//Successes = GameObject.FindGameObjectsWithTag("Correct").OrderBy(f => f.name).ToList();
		for (int i = 0; i < Fails.Count;i++)
		{
			Successes[i].SetActive(false);
			Fails[i].SetActive(false);
		}
		for(int i = 0; i < Minigame3Data1.round; i++)
		{

			print(Minigame3Data1.perfect[player, i]);
			if (Minigame3Data1.perfect[player, i])
			{
				Successes[i].SetActive(true);
			}
			else
			{
				Fails[i].SetActive(true);
			}
		}
	}
	IEnumerator Change(){
		yield return new WaitForSeconds (1);
		//Minigame3Data.round = NextRound;
		int P1Score = 0;
		int P2Score = 0;


		/*if (NextRound < 0)
		{
	
			for (int y = 0; y < 4; y++)
			{
				if (Minigame3Data1.perfect[0, y]) { P1Score++; }
				if (Minigame3Data1.perfect[1, y]) { P2Score++; }
			}
		
		}
		*/
		Minigame3Data1.clear ();
		SceneManager.LoadScene(GoTo);


		//Next.SetActive (true);
		//Current.SetActive (false);

	}
	//*/
	// Update is called once per frame
	void Update () {
		//gameObject.GetComponent<Text>().text = Minigame3Data.Scores[player,Minigame3Data.round].ToString();
		if (Minigame3Data1.Scores[player,Minigame3Data1.round] == (100 * Ingredients) && Minigame3Data1.Checked[player,Minigame3Data1.round] == Ingredients)
		{
			Successes[Minigame3Data1.round].SetActive(true);
			Minigame3Data1.perfect[player, Minigame3Data1.round] = true;
			//print("Win");
			gameObject.GetComponent<Text>().text = "You win!";
		}
		else if (Minigame3Data1.Checked[player, Minigame3Data1.round] == Ingredients)
		{
			Fails[Minigame3Data1.round].SetActive(true);
		}
		if (Minigame3Data1.Checked[0, Minigame3Data1.round] == Ingredients && Minigame3Data1.Checked[1, Minigame3Data1.round] == Ingredients && !changed)
		{
			changed = true;
			print("End");
			StartCoroutine("Change");
		};
	}
}
