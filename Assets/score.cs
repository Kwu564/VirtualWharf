using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class score : MonoBehaviour {
    public int player;
	//public Image FailIcon;
	//public GameObject Current;
	public int NextRound;
    public string GoTo;
    public List<GameObject> Fails;
    public List<GameObject> Successes;
	public int Ingredients;
	// Use this for initialization
	void Start () {
        print(Minigame3Data.Scores[player, Minigame3Data.round]);
        //Fails = GameObject.FindGameObjectsWithTag("Fail").OrderBy(f => f.name).ToList();
        //Successes = GameObject.FindGameObjectsWithTag("Correct").OrderBy(f => f.name).ToList();
        for (int i = 0; i < Fails.Count;i++)
        {
            Successes[i].SetActive(false);
            Fails[i].SetActive(false);
        }
        for(int i = 0; i < Minigame3Data.round; i++)
        {

            print(Minigame3Data.perfect[player, i]);
            if (Minigame3Data.perfect[player, i])
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
        Minigame3Data.round = NextRound;
        SceneManager.LoadScene(GoTo);
		//Next.SetActive (true);
		//Current.SetActive (false);
		
	}
	// Update is called once per frame
	void Update () {
        //gameObject.GetComponent<Text>().text = Minigame3Data.Scores[player,Minigame3Data.round].ToString();
        if (Minigame3Data.Scores[player,Minigame3Data.round] == (100 * Ingredients) && Minigame3Data.Checked[player,Minigame3Data.round] == Ingredients)
        {
            Successes[Minigame3Data.round].SetActive(true);
            Minigame3Data.perfect[player, Minigame3Data.round] = true;
            //print("Win");
            gameObject.GetComponent<Text>().text = "You win!";
        }
        else if (Minigame3Data.Checked[player, Minigame3Data.round] == Ingredients)
        {
            Fails[Minigame3Data.round].SetActive(true);
        }
        if (Minigame3Data.Checked[0, Minigame3Data.round] == Ingredients && Minigame3Data.Checked[1, Minigame3Data.round] == Ingredients)
        {
            print("End");
            StartCoroutine("Change");
        };
	}
}
