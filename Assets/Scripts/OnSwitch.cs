using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allows access to Button type
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class OnSwitch : MonoBehaviour {
    // The UI type that triggers our switch mechanism
    public Button button;
    public Text WhoseTurn;
    public GameObject Trophy;
    public Text TrophyText;
    public GameObject cam;
    public GameObject Player1, Player2;
    // Use this for initialization
    void Awake()
    {
        //GlobalData.turn = 0;
        //GameObject.Find("Player1").GetComponent<MoveTo>().isMoving = true;
        //GameObject.Find("Player2").GetComponent<MoveTo>().isMoving = false;
    }
    void Start () {
        // Get the Button component
        Button btn = button.GetComponent<Button>();
        
        // Add a listener that listens to clicks
        btn.onClick.AddListener(TaskOnClick);
	}
	
    // Click triggers switch
    public void TaskOnClick()
    {
        StartCoroutine("EndOfTurn");
        
    }

    IEnumerator EndOfTurn()
    {
        print("working on it");
        yield return new WaitUntil(GlobalData.getWharf);
        
        //yield return new WaitForSeconds(2f);
        if (GameObject.Find("Player1").GetComponent<MoveTo>().isMoving)
        {
            WhoseTurn.text = "";
            if (GlobalData.MinigameWinner == 0)
            {
                Trophy.SetActive(true);
                TrophyText.text = "P1 won a "+ GlobalData.Inventory[0].Last().name;
                Sprite item = GlobalData.Inventory[0].Last().GetComponent<SpriteRenderer>().sprite;
                GameObject current = Trophy.transform.Find("Item").gameObject;
                current.GetComponent<Image>().sprite = item;
                print("Winner is: " + (GlobalData.MinigameWinner + 1));
                yield return new WaitForSeconds(3f);
                Trophy.SetActive(false);

            }
            yield return new WaitUntil(() => Player2 != null);
            cam.GetComponent<CameraFollow>().target = Player2.transform;
            yield return new WaitWhile(GlobalData.GetCamMoving);
            GameObject.Find("Player1").GetComponent<MoveTo>().isMoving = false;
            if (GlobalData.MinigameWinner == 1)
            {
                yield return new WaitWhile(GlobalData.GetCamMoving);
                Trophy.SetActive(true);
                TrophyText.text = "P2 won a trophy!";
                Sprite item = GlobalData.Inventory[1].Last().GetComponent<SpriteRenderer>().sprite;
                GameObject current = Trophy.transform.Find("Item").gameObject;
                current.GetComponent<Image>().sprite = item;
                yield return new WaitForSeconds(2f);
                print("Winner is: " + (GlobalData.MinigameWinner + 1));
                Trophy.SetActive(false);
            }
            WhoseTurn.text = "Player 2's Turn";
            GameObject.Find("Player2").GetComponent<MoveTo>().isMoving = true;
            GameObject.Find("Player2").GetComponent<MoveTo>().moved = false;
            GameObject.Find("Player2").GetComponent<MoveTo>().clicked = false;
            Debug.Log("Switch to 2");
            GlobalData.MinigameWinner = -1;
            /*GameObject.Find("Player2").GetComponent<MoveTo>().agent.isStopped = true;
            GameObject.Find("Player1").GetComponent<MoveTo>().isMoving = true;            
            GameObject.Find("Player2").GetComponent<MoveTo>().isMoving = false;*/
            GlobalData.turn += 1;
        }
        else
        {
            WhoseTurn.text = "";
            if (GlobalData.MinigameWinner == 1)
            {
                Trophy.SetActive(true);
                TrophyText.text = "P2 won a trophy!";
                Sprite item = GlobalData.Inventory[1].Last().GetComponent<SpriteRenderer>().sprite;
                GameObject current = Trophy.transform.Find("Item").gameObject;
                current.GetComponent<Image>().sprite = item;
                yield return new WaitForSeconds(2f);
                print("Winner is: " + (GlobalData.MinigameWinner + 1));
                Trophy.SetActive(false);
            }
            yield return new WaitUntil(() => Player1 != null);

            cam.GetComponent<CameraFollow>().target = Player1.transform;
            yield return new WaitWhile(GlobalData.GetCamMoving);
            if (GlobalData.MinigameWinner == 0)
            {
                yield return new WaitWhile(GlobalData.GetCamMoving);
                Trophy.SetActive(true);
                TrophyText.text = "P1 won a trophy!";
                try
                {
                    Sprite item = GlobalData.Inventory[0].Last().GetComponent<SpriteRenderer>().sprite;
                    Trophy.GetComponent<Image>().sprite = item;
                    GameObject current = Trophy.transform.Find("Item").gameObject;
                    current.GetComponent<Image>().sprite = item;
                }
                catch { }
                yield return new WaitForSeconds(2f);
                print("Winner is: " + (GlobalData.MinigameWinner + 1));
                Trophy.SetActive(false);
            }
            WhoseTurn.text = "Player 1's Turn";
            GameObject.Find("Player1").GetComponent<MoveTo>().isMoving = true;
            GameObject.Find("Player2").GetComponent<MoveTo>().isMoving = false;
            GameObject.Find("Player1").GetComponent<MoveTo>().moved = false;
            GameObject.Find("Player1").GetComponent<MoveTo>().clicked = false;
            GlobalData.MinigameWinner = -1;
            Debug.Log("Switch to 1");
            /*GameObject.Find("Player2").GetComponent<MoveTo>().isMoving = true;
            GameObject.Find("Player1").GetComponent<MoveTo>().agent.isStopped = true;
            GameObject.Find("Player1").GetComponent<MoveTo>().isMoving = false;*/
            GlobalData.turn += 1;
        }
        
        StartCoroutine("Dissappear");
        Debug.Log("Switch players!");

    }

    IEnumerator Dissappear()
    {
        yield return new WaitForSeconds(1.5f);
        WhoseTurn.text = "";
    }
}
